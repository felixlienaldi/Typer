using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class WordManager : MonoBehaviour
{

    public List<Word> words;
    public List<int> distinct;
    public string[] wordList;
    public bool isActive;
    public int enemyType;
    public int index;
    public Word activeWord;
    public TextAsset textFile;
    public SpawnManager spawn;
    public ScoreManager score;
    public Image comboBar;



    // Start is called before the first frame update
    void Awake()
    {
       GenerateWord();
    }


    void Start()
    {

    }
    
    void Update()
    {
    }

    void GenerateWord()
    {
        if(textFile != null)
        {
            wordList = (textFile.text.Split('\n'));
        }
    }

    string GetWord()
    {
        do
        {
            index = Random.Range(0, wordList.Length);
        } while (distinct.IndexOf(index) != -1);
        distinct.Add(index);

        string word = wordList[index];

        if( word.Length <= 4)
        {
            enemyType = 1;
        }else if(word.Length <= 6)
        {
            enemyType = 2;
        }else if(word.Length <= 8)
        {
            enemyType = 3;
        }
        else
        {
            enemyType = 4;
        }
            
        return word;
    }

    

    public void AddWord()
    {
        Word word = new Word(GetWord(), spawn.Spawn());
        words.Add(word);
    }
    
    public void input(string _alphabet)
    {
        score.totalType++;
        
        if (isActive)
        {
            if(activeWord.GetNext() == _alphabet[0])
            {
                activeWord.IsTyping();
                comboBar.fillAmount += 0.025f;
                if (comboBar.fillAmount == 1f)
                {
                    comboBar.fillAmount = 0f;
                    score.combo++;
                }
            }
            else
            {
                score.combo = 1f;
                comboBar.fillAmount = 0f;
            }
            
        }
        else
        {
            foreach(Word word in words)
            {
                if(word.GetNext() == _alphabet[0])
                {
                    comboBar.fillAmount += 0.025f;
                    if (comboBar.fillAmount == 1f)
                    {
                        comboBar.fillAmount = 0f;
                        score.combo++;
                    }
                    activeWord = word;
                    isActive = true;
                    word.IsTyping();
                    break;
                }
                else
                {
                    score.combo = 1f;
                    comboBar.fillAmount = 0f;
                }
            }
            
        }

        if (isActive && activeWord.IsFinished())
        {
            score.CalculateScore();
            isActive = false;
            spawn.wordCount -= 1;
            if (spawn.wordCount <= 0)
            {
                words.Remove(activeWord);
                spawn.wordTimer += Random.Range(2f, 6f);
                DisplayWord.speedChangeX += 0.05f;
                DisplayWord.speedChangeY += 0.375f;
                SpawnManager.wave++;
                distinct.Clear();
                spawn.isDone = true;
            }
        }


    }
}
