using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public Sprite[] sprite;
    public static int wave = 1;
    public GameObject wordObject;
    public GameObject waveTextObj;
    public GameObject scoreTextObj;
    public GameObject bomb;
    public Transform canvas;
    public int wordCount;
    public float wordDelay;
    public float wordTimer;
    public float waveBreak;
    public bool isDone;
    
    public DisplayWord Spawn()
    {
        Vector3 position = new Vector3(Random.Range(-2.3f, 2.3f), 7f ,-1f);
        GameObject wordPrefab = Instantiate(wordObject, position ,Quaternion.identity);
        switch (GetComponent<WordManager>().enemyType)
        {
            case 1: wordPrefab.GetComponent<SpriteRenderer>().sprite = sprite[Random.Range(0, 2)]; break;
            case 2: wordPrefab.GetComponent<SpriteRenderer>().sprite = sprite[Random.Range(3, 5)]; break;
            case 3: wordPrefab.GetComponent<SpriteRenderer>().sprite = sprite[Random.Range(6, 8)]; break;
            case 4: wordPrefab.GetComponent<SpriteRenderer>().sprite = sprite[Random.Range(9, 11)]; break;
        }
        wordPrefab.AddComponent<PolygonCollider2D>();
        wordPrefab.GetComponent<PolygonCollider2D>().isTrigger = true;
        DisplayWord Display = wordPrefab.GetComponent<DisplayWord>();

        
        return Display;
    }

    public void Bomb()
    {
        bomb.SetActive(true);
    }
    
    public void Update()
    {
        WaveClear();
    }
    public void WaveClear()
    {
        if (isDone)
        {
            waveTextObj.SetActive(true);
            scoreTextObj.SetActive(true);
            waveBreak += Time.deltaTime;
        }
        if(waveBreak >= 3f)
        {
            waveTextObj.SetActive(false);
            scoreTextObj.SetActive(false);
            waveBreak = 0f;
            isDone = false;
            StartCoroutine(SpawnDelay());
        }
    }

    public IEnumerator SpawnDelay()
    {       
        yield return new WaitForSeconds(wordDelay);
        GetComponent<WordManager>().AddWord();
        wordCount++;
        StartCoroutine(SpawnDelay());
        yield return new WaitForSeconds(wordTimer);
        StopAllCoroutines();
    }
}
