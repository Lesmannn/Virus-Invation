using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public static Vector2 lastCheckpoint = new Vector2(-12, 0);
    
	private void Awake()
	{
		GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckpoint;
	}
}
