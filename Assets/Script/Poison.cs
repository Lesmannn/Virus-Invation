using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
	public float time = 0;
	public GameObject Darah;
	[SerializeField]
	private GameObject poison;

	void Start()
	{
		poison.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Player"))
		{
			col.GetComponent<Chara>().CheckShield();
			Destroy(gameObject);
			for (int i = 0; i < 3; i++)
			{
				Chara ps = col.GetComponent<Chara>();
				ps.currentHP -= 1;
				UIManager.instance.UpdateHealthBar(ps.currentHP, ps.maxHP);
				poison.SetActive(true);
				GameObject go = Instantiate(Darah, transform.position, Quaternion.identity);
			}
			Destroy(poison, 2f);
		}
	}
}
