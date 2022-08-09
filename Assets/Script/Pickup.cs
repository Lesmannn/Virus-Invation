using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
	Health, Ammo, Power
}

public class Pickup : MonoBehaviour
{
	public PickupType type; 
	public int value;
	public string popUp;
	public GameObject stun;

	public float rotateSpeed;
	public float bobSpeed;
	public float bobHeight;

	private Vector3 startPos;
	private bool bobbingUp;

	private void Start()
	{
		startPos = transform.position;
	}

	private void Update()
	{
		transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

		Vector3 offset = (bobbingUp == true ? new Vector3(0, bobHeight / 2, 0) : new Vector3(0, -bobHeight / 2, 0));

		transform.position = Vector3.MoveTowards(transform.position, startPos + offset, bobSpeed * Time.deltaTime);

		if(transform.position == startPos + offset)
		{
			bobbingUp = !bobbingUp;
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag.Equals ("Player"))
		{
			Chara player = col.GetComponent<Chara>();

			switch (type)
			{
				case PickupType.Health :
					player.GiveHealth(value);
					FindObjectOfType<Stun>().Stop(1f);
					stun.SetActive(true);
					Destroy(stun, 0.1f);
				break;
				case PickupType.Ammo :
					player.GiveAmmo(value);
					PopUp pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUp>();
					pop.PopUpScreen(popUp);
					player.kecepatan -= 1;
				break;
				//case PickupType.Power :
				//	player.GivePower(value);
				//break;
			}
			Destroy (gameObject);

		}
	}
}
