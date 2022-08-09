using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transisi2 : MonoBehaviour
{
	public Image TargetImage;
	public float FadeSpeed;
	public float delay;
	bool StartFadeOut = false;
	// Start is called before the first frame update
	void Awake()
	{
		TargetImage.rectTransform.localScale = new Vector2 (Screen.width, Screen.height);
		TargetImage.enabled = false;
		TargetImage.color = Color.clear;
	}
	void Start()
	{
		Invoke("SetStartFadeOut", delay);
	}

	// Update is called once per frame
	void Update()
	{
		if (StartFadeOut)
		{
			FadeOut();
		}
	}
	void FadeOut()
	{
		TargetImage.color = Color.Lerp(TargetImage.color, Color.black, FadeSpeed * Time.deltaTime);
	}
	void SetStartFadeOut()
	{
		StartFadeOut = true;
		TargetImage.enabled = true;
	}
}
