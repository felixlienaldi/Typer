using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static float totalTypeRight;
    public float highScore;
    public float accuracy = 0f;
    public float score;
    public float totalType;
    public float combo = 1f;
    public Text scoreText;
    public Text waveText;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        CalculateAccuracy();
        ShowText();
	}
    void ShowText()
    {
        scoreText.text = "Score : " + score;
        waveText.text = "Wave : " + SpawnManager.wave;
    }
    public void CalculateScore()
    {
        score += 15 * combo;
    }

    public void CheckHighScore()
    {
        if(score > highScore)
        {
            highScore = score;
        }
    }

    public void CalculateAccuracy()
    {
        if(totalTypeRight != 0f)
        {
            accuracy = totalTypeRight / totalType * 100;
        }
            
       
    }
}
