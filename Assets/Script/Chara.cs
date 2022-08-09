using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chara : MonoBehaviour
{
	[SerializeField]
	private Rigidbody2D rigid;

	private Weapon weapon;
	public Animator anim;

	[SerializeField]
	public float kecepatan = 5;

	[SerializeField]
	private float Lompat = 5;

	public float horizontalMove;
	public bool facingRight = true;
	private bool tanah = true;
	public bool shielded;
	public int currentHP;
	public int maxHP;
	public Transform attackPoint;
	public float attackRange;
	public LayerMask EnemyLayer;
	public int damage;
	//public GameObject attack;

	//private float dirX = 5f;

	[SerializeField]
	private int jumlahLompat;

	[SerializeField]
	private int banyakLompat=1;

	[SerializeField]
	private GameObject Shield;


    // Start is called before the first frame update
	private void Awake()
	{
		weapon = GetComponent<Weapon>();
	}
	private void Start()
	{
		UIManager.instance.UpdateHealthBar(currentHP, maxHP);
		UIManager.instance.UpdateAmmoText(weapon.currentAmmo, weapon.maxAmmo);
		anim = GetComponent<Animator>();
		shielded = false;
		Shield.SetActive(false);
	}

    // Update is called once per frame
    private void Update()
    {
		Move();
		SetFlip();
		AnimationState();
		if (Input.GetKey(KeyCode.E))
		{
			Attack();
		}
		if (Input.GetKeyDown(KeyCode.UpArrow)&& jumlahLompat > 0)
		{
			lompat();
			GameObject.Find("flap").GetComponent<AudioSource>().Play();
		}

		if (tanah)
		{
			jumlahLompat = banyakLompat;
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if(weapon.CanShoot())
			{
				weapon.Shoot();
			}
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadScene("Change_Character");
		}
    }

	private void FixedUpdate()
	{
		SetMove();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (!tanah)
		{
			tanah = true;
		}
	}

	public void Move()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * kecepatan;
	}

	public void SetMove()
	{
		rigid.velocity = new Vector2(horizontalMove, rigid.velocity.y);
	}

	public void SetFlip()
	{
		if (horizontalMove < 0 && facingRight)
		{
			Flip();
		}
		if (horizontalMove > 0 && !facingRight)
		{
			Flip();
		}
	}

	public void Flip()
	{
		facingRight = !facingRight;
		transform.Rotate(0, 180, 0);
	}

	public void lompat()
	{
		rigid.velocity = Vector2.up * Lompat;
		tanah = false;
		jumlahLompat--;
	}	
	public void GiveAmmo(int AmmountToGive)
	{
		weapon.currentAmmo = Mathf.Clamp(weapon.currentAmmo + AmmountToGive, 0, weapon.maxAmmo);
		UIManager.instance.UpdateAmmoText(weapon.currentAmmo, weapon.maxAmmo);
	}
	public void GiveHealth(int AmmountToGive)
	{
		currentHP = Mathf.Clamp(currentHP + AmmountToGive, 0, maxHP);
		UIManager.instance.UpdateHealthBar(currentHP, maxHP);
	}
	public void Mati()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public void takeDamage(int damage)
	{
		if (!shielded)
		{
			currentHP -= damage;
			UIManager.instance.UpdateHealthBar(currentHP, maxHP);
			if (currentHP <= 0)
			{
				Mati();
			}
		}
	}
	void AnimationState()
	{
		if (horizontalMove == 0)
		{
			anim.SetBool("isRun", false);
			anim.SetBool("isRun2", false);
		}
		if (rigid.velocity.y == 0)
		{
			anim.SetBool("isJump", false);
			anim.SetBool("isJump2", false);
		}
		if (Mathf.Abs(horizontalMove) >= 5)
		{
			anim.SetBool("isRun", true);
			anim.SetBool("isRun2", true);
		}
		else
		{
			anim.SetBool("isRun", false);
			anim.SetBool("isRun2", false);
		}
		if (rigid.velocity.y > 1)
		{
			anim.SetBool("isJump", true);
			anim.SetBool("isJump2", true);
		}
		if (rigid.velocity.y < 0)
		{
			anim.SetBool("isJump", false);
			anim.SetBool("isJump2", false);
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			anim.SetTrigger("isAttack2");
		}
	}
	public void CheckShield()
	{
		Shield.SetActive(true);
		shielded = true;
		Invoke("NoShield", 6f);
	}
	public void NoShield()
	{
		Shield.SetActive(false);
		shielded = false;
	}
	public void Attack()
	{
		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, EnemyLayer);

		foreach(Collider2D enemy in hitEnemies)
		{
			enemy.GetComponent<Enemy>().takeDamage(damage);
		}
	}
	void OnDrawGizmosSelected()
	{
		if (attackPoint == null)
		{
			return;
		}
		Gizmos.DrawWireSphere(attackPoint.position, attackRange);
	}

}
