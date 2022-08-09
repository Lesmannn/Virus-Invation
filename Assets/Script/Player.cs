using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public int currentHP;
	public int maxHP;
	public float moveSpeed;
	public int jumpForce;

	public float lookSensitive;
	public float maxLookX;
	public float minLookX;
	private float rotX;

	private Camera cam;
	private Rigidbody rb;
	private Weapon weapon;

	private void Awake()
	{
		cam = Camera.main;
		rb = GetComponent<Rigidbody>();
		weapon = GetComponent<Weapon>();

		Cursor.lockState = CursorLockMode.Locked;
	}
	private void Start()
	{
		UIManager.instance.UpdateHealthBar(currentHP, maxHP);
		UIManager.instance.UpdateAmmoText(weapon.currentAmmo, weapon.maxAmmo);
		UIManager.instance.UpdateScoreText(0);
	}
	private void Update()
	{
		if(GameManager.instance.gamePaused == true)
		{
			return;
		}
		Move();
		if(Input.GetButtonDown("Jump"))
		{
			TryJump();
		}
		if (Input.GetButton("Fire1"))
		{
			if(weapon.CanShoot())
			{
				weapon.Shoot();
			}
		}
		CameraLook();
	}

	void Move()
	{
		float x = Input.GetAxis("Horizontal") * moveSpeed;
		float z = Input.GetAxis("Vertical") * moveSpeed;

		Vector3 dir = transform.right * x + transform.forward * z;
		dir.y = rb.velocity.y;
		rb.velocity = dir;

	}
	void CameraLook()
	{
		float y = Input.GetAxis("Mouse X") * lookSensitive;
		rotX += Input.GetAxis("Mouse Y") * lookSensitive;
		rotX = Mathf.Clamp(rotX, minLookX, maxLookX);

		cam.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
		transform.eulerAngles += Vector3.up * y;
	}
	void TryJump()
	{
		Ray ray = new Ray(transform.position, Vector3.down);
		if(Physics.Raycast(ray, 1.1f))
		{
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}
	}
	public void takeDamage(int damage)
	{
		currentHP -= damage;
		UIManager.instance.UpdateHealthBar(currentHP, maxHP);
		if (currentHP <= 0)
		{
			Die();
		}
	}
	void Die()
	{
		GameManager.instance.LoseGame();
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
}
