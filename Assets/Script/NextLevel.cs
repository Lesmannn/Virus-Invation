using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLevel : MonoBehaviour
{
	public int nextLevel;
	public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
		nextLevel = SceneManager.GetActiveScene().buildIndex;
    }

	public void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			SceneManager.LoadScene(sceneName);

			if (nextLevel > PlayerPrefs.GetInt("LevelAt"))
			{
				PlayerPrefs.SetInt("LevelAt", nextLevel);
			}
		}
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.P))
		{
			PlayerPrefs.DeleteAll();
		}
    }
}
