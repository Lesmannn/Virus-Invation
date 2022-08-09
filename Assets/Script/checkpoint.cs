using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkpoint : MonoBehaviour
{
	public bool Level;
	public string sceneName;

	private void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if (Level)
			{
				SceneManager.LoadScene(0);
			}
			else
			{
				AddManager.instance.PlayAdd();
				SceneManager.LoadScene(sceneName);
			}
		}
	}
}
