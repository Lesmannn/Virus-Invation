using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag.Equals ("Player")) {
			Destroy (gameObject);
			Penghitung_Coin.hitungCoin += 50;
			GameObject.Find("coin").GetComponent<AudioSource>().Play();
		}
	}
	public void OnShowAddButton()
	{
		Penghitung_Coin.hitungCoin += 250;
		AddManager.instance.PlayAdd();
	}
}