using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
	public float speed;
	private float horizontalMove;
	public float tinggi;
	private bool facingRight = true;
	private bool tanah = true;
	private Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
		rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		SetMove();
		SetFlip();
		if (Input.GetKeyDown(KeyCode.UpArrow) && tanah)
		{
			lompat();
		}
    }
	public void SetMove()
	{
		horizontalMove = Input.GetAxis("Horizontal") * speed;
		rigid.velocity = new Vector2 (horizontalMove, rigid.velocity.y);
	}
	public void lompat()
	{
		rigid.velocity = Vector2.up * tinggi;
		tanah = false;
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (!tanah)
		{
			tanah = true;
		}
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

}
