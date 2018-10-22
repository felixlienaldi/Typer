using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word 
{
    public string word;
    public int index;
    DisplayWord display;

    public Word(string _word, DisplayWord _display)
    {

        word = _word;
        index = 0;


        display = _display;
        display.ShowWord(word);
        
    }

    public char GetNext(){
        return word[index];
    }

    public void IsTyping()
    {
        index++;
        ScoreManager.totalTypeRight++;
        display.RemoveAlphabet();
       
    }

    public bool IsFinished()
    {
        if (index >= word.Length - 1)
        {
            display.RemoveWord();
        }

        return index >= word.Length - 1;
        //enter kebaca
    }

}
