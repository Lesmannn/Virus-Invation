using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.RightArrow))
		{
			transform.Rotate(0, 0, 0);
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
		{
			transform.Rotate(180, 180, 0);
		}
    }
}
