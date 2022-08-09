using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CS : MonoBehaviour
{
	[SerializeField] private float JumpForce = 400f;
	[Range(0,1)] [SerializeField] private float CrouchSpeed = .36f;
	[Range(0, .3f)] [SerializeField] private float MoveSmooth = .05f;
	[SerializeField] private bool AirControl = false;
	[SerializeField] private LayerMask WhatIsGround;
	[SerializeField] private Transform CheckGround;
	[SerializeField] private Transform CheckCeiling;
	[SerializeField] private Collider2D CrouchDisableCollider;

	const float GroundedRadius = .2f;
	private bool Grounded;
	const float CeilingRadius = .2f;
	private Rigidbody2D rb;
	private bool FacingRight = true;
	private Vector3 Velocity = Vector3.zero;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;
	public class BoolEvent : UnityEvent<bool> { }

	public BoolEvent OnCrouchEvent;
	private bool WasCrouching = false;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
		{
			OnLandEvent = new UnityEvent();
		}

		if (OnCrouchEvent == null)
		{
			OnCrouchEvent = new BoolEvent();
		}
	}

	private void FixedUpdate()
	{
		bool WasGrounded = Grounded;
		Grounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(CheckGround.position, GroundedRadius, WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				Grounded = true;
				if (!WasGrounded)
				{
					OnLandEvent.Invoke();
				}
			}
		}
	}

	public void Move(float move, bool crouch, bool jump)
	{
		if (!crouch)
		{
			if (Physics2D.OverlapCircle(CheckCeiling.position, CeilingRadius, WhatIsGround))
			{
				crouch = true;
			}
		}

		if (Grounded || AirControl)
		{
			if (crouch)
			{
				if (WasCrouching)
				{
					WasCrouching = true;
					OnCrouchEvent.Invoke(true);
				}

				move *= CrouchSpeed;

				if (CrouchDisableCollider != null)
				{
					CrouchDisableCollider.enabled = false;
				}
			}
			else
			{
				if (CrouchDisableCollider != null)
				{
					CrouchDisableCollider.enabled = true;
				}

				if (WasCrouching)
				{
					WasCrouching = false;
					OnCrouchEvent.Invoke(false);
				}
			}

			Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
			rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref Velocity, MoveSmooth);

			if (move > 0 && !FacingRight)
			{
				Flip();
			}
			else if (move < 0 && FacingRight)
			{
				Flip();
			}
		}

		if (Grounded && jump)
		{
			Grounded = false;
			rb.AddForce(new Vector2(0f, JumpForce));
		}
	}

	private void Flip()
	{
		FacingRight = !FacingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
