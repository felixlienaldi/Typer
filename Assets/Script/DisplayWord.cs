using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayWord : MonoBehaviour {

    private Rigidbody2D rb;
    public static float speedChangeX = 0.15f;
    public static float speedChangeY = 2.5f;
    public TextMeshPro wordText;
    public float speed = 1f;
    public Transform target;
    public Vector2 direction;
    public string wordChecker;
    public WordManager word;
    public bool isDestroyable;
    public GameManager gameManager;

    void Start()
    {
        target = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        word = GameObject.Find("GameManager").GetComponent<WordManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        direction = (target.position - transform.position).normalized;
        rb.velocity = new Vector3(direction.x * speed * speedChangeX * Time.deltaTime, -speed * speedChangeY * Time.deltaTime, -1f);
    }

    public void ShowWord(string word)
    {
        wordText.text = word;
        wordChecker = word;
    }

    public void RemoveAlphabet()
    {
        PlayerManager.instance.target = this.gameObject.transform;
        PlayerManager.instance.ChangeTarget();
        wordText.color = Color.blue;
      

    }

    public void RemoveWord()
    {
        PlayerManager.instance.target = null;
        PlayerManager.instance.transform.rotation = Quaternion.identity;
        isDestroyable = true;
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            if(wordChecker == word.activeWord.word)
            {
                wordText.text = wordText.text.Remove(0, 1);
                Destroy(col.gameObject);
                if (isDestroyable)
                {
                    isDestroyable = false;
                    Destroy(gameObject);
                }
            }

        }

        if(col.gameObject.tag == "Player")
        {
            gameManager.GameOverMenu();
        }
    }
}
