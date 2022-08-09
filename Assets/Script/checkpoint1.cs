using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint1 : MonoBehaviour
{
	private bool inRange;
//	public GameObject objectOn;
//	public GameObject objectOff;
	private bool isOn;

	public SpriteRenderer SwitchSprite;
	public Sprite onSprite;

	private void Update()
	{
		if (inRange)
		{
			isOn = !isOn;
			if(isOn)
			{
				SwitchSprite.sprite = onSprite;
			}
		}
	}

	private void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			inRange = true;
		}
		if(other.transform.tag == "Player")
		{
			PlayerManager.lastCheckpoint = transform.position;
		}
	}
	private void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			inRange = false;
		}
	}
		
}
