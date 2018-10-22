using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    public GameObject settings;
    public GameObject menu;
    public GameObject on;
    public GameObject off;
	// Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

	void Start () {
        
     
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void StartButton()
    {

        SceneManager.LoadScene(1);
    }

    public void Setting()
    {
        settings.SetActive(true);
        menu.SetActive(false);
    }
    public void Sound()
    {
        if (AudioListener.volume !=0 )
        {
            on.SetActive(false);
            off.SetActive(true);
            AudioListener.volume = 0f;
        }
        else
        {
            on.SetActive(true);
            off.SetActive(false);
            AudioListener.volume = 1f;
        }
    }

    public void ExitToMainMenu()
    {
        settings.SetActive(false);
        menu.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
