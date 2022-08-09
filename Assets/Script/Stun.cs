using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : MonoBehaviour
{
	bool waiting;
	[SerializeField]
	private GameObject stun;

	public void Stop(float duration)
	{
		if (waiting)
		{
			return;
		}
		Time.timeScale = 0.0f;
		StartCoroutine(Wait(duration));
		stun.SetActive(true);
	}

	IEnumerator Wait(float duration)
	{
		waiting = true;
		yield return new WaitForSecondsRealtime(duration);
		Time.timeScale = 1.0f;
		waiting = false;
		stun.SetActive(false);
	}
}
