using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	public TextMeshProUGUI ScoreText;
	public TextMeshProUGUI AmmoText;
	public Image healthBarFill;

	public GameObject Pause;

	public GameObject EndGame;
	public TextMeshProUGUI endGameHeaderText;
	public TextMeshProUGUI endGameScoreText;

	public static UIManager instance;

	private void Awake()
	{
		instance = this;
	}
	public void UpdateHealthBar(int currentHP, int maxHP)
	{
		healthBarFill.fillAmount = (float)currentHP / (float)maxHP;
	}
	public void UpdateAmmoText(int currentAmmo, int maxAmmo)
	{
		AmmoText.text = "Ammo : " + currentAmmo + " / " + maxAmmo;
	}
	public void UpdateScoreText(int score)
	{
		ScoreText.text = "Score " + score;
	}
	public void TogglePauseMenu(bool paused)
	{
		Pause.SetActive(paused);
	}
	public void SetEndGameScreen(bool won, int score)
	{
		EndGame.SetActive(true);
		endGameScoreText.text = won == true ? "You Won" : "You Lose";
		endGameScoreText.color = won == true ? Color.green : Color.red;
		endGameHeaderText.text = "<b>Score</b>\n" + score;
	}

	public void OnResumeButton()
	{
		GameManager.instance.TogglePausedGame();
	}
	public void OnRestartButton()
	{
		SceneManager.LoadScene("inGame");
	}
	public void OnMenuButton()
	{
		SceneManager.LoadScene("Menu");
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
