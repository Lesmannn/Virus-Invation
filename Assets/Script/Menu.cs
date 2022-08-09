using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	public void Narasi()
	{
		SceneManager.LoadScene("NarasiAwal");
	}
	public void NarasiSemua()
	{
		SceneManager.LoadScene("NarasiSemua");
	}
	public void NarasiSemuaDark()
	{
		SceneManager.LoadScene("NarasiSemuaDark");
	}
	public void NarasiDark()
	{
		SceneManager.LoadScene("NarasiAwalDark");
	}
    public void StartButton()
	{
		SceneManager.LoadScene("Level1");
	}
	public void StartButtonDark()
	{
		SceneManager.LoadScene("Level1Dark");
	}
	public void Level2()
	{
		SceneManager.LoadScene("Level2");
	}
	public void Level2Dark()
	{
		SceneManager.LoadScene("Level2Dark");
	}
	public void Level3()
	{
		SceneManager.LoadScene("Level3");
	}
	public void Level3Dark()
	{
		SceneManager.LoadScene("Level3Dark");
	}
	public void Level4()
	{
		SceneManager.LoadScene("Level4");
	}
	public void Level4Dark()
	{
		SceneManager.LoadScene("Level4Dark");
	}
	public void Level5()
	{
		SceneManager.LoadScene("Level5");
	}
	public void Level5Dark()
	{
		SceneManager.LoadScene("Level5Dark");
	}
	public void Level6()
	{
		SceneManager.LoadScene("Level6");
	}
	public void Level6Dark()
	{
		SceneManager.LoadScene("Level6Dark");
	}
	public void Level7()
	{
		SceneManager.LoadScene("Level7");
	}
	public void Level7Dark()
	{
		SceneManager.LoadScene("Level7Dark");
	}
	public void Level8()
	{
		SceneManager.LoadScene("Level8");
	}
	public void Level8Dark()
	{
		SceneManager.LoadScene("Level8Dark");
	}
	public void Level9()
	{
		SceneManager.LoadScene("Level9");
	}
	public void Level9Dark()
	{
		SceneManager.LoadScene("Level9Dark");
	}
	public void Level10()
	{
		SceneManager.LoadScene("Level10");
	}
	public void Level10Dark()
	{
		SceneManager.LoadScene("Level10Dark");
	}
	public void Level11()
	{
		SceneManager.LoadScene("LevelHidden");
	}
	public void Level11Dark()
	{
		SceneManager.LoadScene("LevelHiddenDark");
	}
	public void LevelSelect()
	{
		SceneManager.LoadScene("LevelSelect");
	}
	public void LevelSelectDark()
	{
		SceneManager.LoadScene("LevelSelectDark");
	}
	public void BackMenu()
	{
		SceneManager.LoadScene("Change_Character");
	}
	public void Change()
	{
		SceneManager.LoadScene("Menu");
	}
	public void HTP()
	{
		SceneManager.LoadScene("HowToPlay");
	}
	public void HTPDark()
	{
		SceneManager.LoadScene("HowToPlayDark");
	}
	public void Exit()
	{
		Application.Quit();
	}
}
