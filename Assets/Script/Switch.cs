using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
	private bool inRange;
	public GameObject objectOff;
	public GameObject objectOn;
	private bool isOn;

	public SpriteRenderer SwitchSprite;
	public Sprite onSprite;
	public Sprite offSprite;

	private void Update()
	{
		if (inRange)
		{
			if(Input.GetMouseButtonDown(0))
			{
				isOn = !isOn;
				if(isOn)
				{
					SwitchSprite.sprite = onSprite;
				}
				else
				{
					SwitchSprite.sprite = offSprite;
				}
				objectOff.SetActive(!isOn);
				objectOn.SetActive(isOn);
			}
		}
	}

	private void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			inRange = true;
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
