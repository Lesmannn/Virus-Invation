using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUp : MonoBehaviour
{
	public GameObject PopUpBox;
	public Animator anim;
	public TMP_Text PopUpText;

	public void PopUpScreen(string text)
	{
		PopUpBox.SetActive(true);
		PopUpText.text = text;
		anim.SetTrigger("pop");
	}
}
