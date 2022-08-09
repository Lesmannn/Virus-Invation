using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextNarasi : MonoBehaviour
{
	public string nextNarasi;
    public void next()
	{
		SceneManager.LoadScene(nextNarasi);
	}
}
