using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
	public int damage;
	public GameObject Darah;

	private void OnTriggerEnter2D (Collider2D col)
	{
		Chara ps = col.GetComponent<Chara>();
		if (ps.shielded == false)
		{
			if (col.CompareTag("Player"))
			{
				col.GetComponent<Chara>().takeDamage(damage);
				GameObject go = Instantiate(Darah, transform.position, Quaternion.identity);
			}
		}
	}
}
