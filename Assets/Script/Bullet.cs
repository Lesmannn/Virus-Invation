using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public int damage;
	public float lifeTime;
	private float shootTime;

	public GameObject Darah;

	private void OnEnable()
	{
		shootTime = Time.time;
	}
	private void Update()
	{
		if (Time.time - shootTime >= lifeTime)
		{
			gameObject.SetActive(false);
		}
	}
	private void OnTriggerEnter2D (Collider2D col)
	{
		if (col.CompareTag("Enemy"))
		{
			col.GetComponent<Enemy>().takeDamage(damage);
			GameObject go = Instantiate(Darah, transform.position, Quaternion.identity);
			Destroy(go, 0.5f);
		}
		gameObject.SetActive(false);
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
