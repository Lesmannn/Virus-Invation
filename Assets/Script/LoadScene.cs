using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
	public string TargetScene;
	public float delay;
    // Start is called before the first frame update
    void Start()
    {
		Invoke("Loading", delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void Loading()
	{
		SceneManager.LoadScene(TargetScene);
	}
}
