using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject pauseObject;
    public GameObject pauseButton;
    public GameObject gameOverObject;
    public ScoreManager score;
    public Text waveText;
    public Text scoreText;
    public Text accuracyText;
	// Use this for initialization
	void Start () {
        score = GetComponent<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PauseMenu()
    {
        Time.timeScale = 0f;
        pauseObject.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void Resume()
    {
        pauseObject.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }
    
    public void ExitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void GameOverMenu()
    {
        waveText.text = "Wave : " + SpawnManager.wave;
        scoreText.text = "Score : " + score.score;
        accuracyText.text = "Accuracy : " + score.accuracy + "%";
        Time.timeScale = 0f;
        gameOverObject.SetActive(true);
    }

}
