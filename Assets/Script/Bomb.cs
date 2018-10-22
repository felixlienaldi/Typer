using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public WordManager word;
    public SpawnManager spawn;
    public GameObject button;

    void Update()
    {
        transform.localScale += new Vector3(1f, 1f, 1f);
        transform.Rotate(Vector3.forward * 400f * Time.deltaTime);
        if (transform.localScale.x >= 51f)
        {
            gameObject.SetActive(false);
            button.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            word.words.Remove(word.activeWord);
            spawn.wordCount--;
            Destroy(col.gameObject);
            word.score.CalculateScore();
            word.isActive = false;
            if (spawn.wordCount <= 0)
            {
                word.words.Clear();
                spawn.wordTimer += Random.Range(2f, 6f);
                DisplayWord.speedChangeX += 0.05f;
                DisplayWord.speedChangeY += 0.375f;
                SpawnManager.wave++;
                word.distinct.Clear();
                spawn.isDone = true;
            }
        }
    }

}
