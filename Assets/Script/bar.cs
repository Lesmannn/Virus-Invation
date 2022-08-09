using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bar : MonoBehaviour
{
	Image Bar;
	public float maxTime = 60f;
	float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
		Bar = GetComponent<Image> ();
		timeLeft = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
		if(timeLeft > 0)
		{
			timeLeft -= Time.deltaTime;
			Bar.fillAmount = timeLeft / maxTime;
		}
		else
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
    }
}
