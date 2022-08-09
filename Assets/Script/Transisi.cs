using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transisi : MonoBehaviour
{
	public Image TargetImage;
	public float FadeSpeed;
    // Start is called before the first frame update
	void Awake()
	{
		TargetImage.rectTransform.localScale = new Vector2 (Screen.width, Screen.height);
	}
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		FadeIn();
    }
	void FadeIn()
	{
		TargetImage.color = Color.Lerp(TargetImage.color, Color.clear, FadeSpeed * Time.deltaTime);
	}
}
