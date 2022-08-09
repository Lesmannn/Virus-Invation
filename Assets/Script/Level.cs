using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
	public Button[] banyakButton;
    // Start is called before the first frame update
    void Start()
    {
		int levelAt = PlayerPrefs.GetInt("LevelAt", 1);

		for (int i=0; i<banyakButton.Length; i++)
		{
			if(i+1 > levelAt)
			{
				banyakButton[i].interactable = false;
			}
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
