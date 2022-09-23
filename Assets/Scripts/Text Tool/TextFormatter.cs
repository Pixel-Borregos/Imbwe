using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TextFormatter 
{

    private Dictionary<int, string> _gameText;

    public TextFormatter( string language)
    {
        _gameText = new Dictionary<int, string>();
        LoadText(language);
    }

    public List<string> GetOutputText( TextEvent textEvent )
    {
        List<string> outputText = new List<string>();
        string fullOutputText = _gameText[textEvent.textIDs[UnityEngine.Random.Range(0,textEvent.textIDs.Count)]];
        List<string> words = fullOutputText.Split(" ").ToList();
        int lines = textEvent.maxLines;
        string currentLine = "";

        foreach (string word in words)
        {
            string tempLine = (currentLine == "") ? word : currentLine + " " + word;

            if ( tempLine.Length > textEvent.maxCharsPerLine)
            {
                if (lines > 0)
                {
                    lines--;
                    currentLine += "\n" + word;
                }
                else
                {
                    outputText.Add(currentLine);
                    currentLine = "";
                    lines = textEvent.maxLines;
                }
            } 
            else
                currentLine = tempLine;  
        }

        if (currentLine != "")
            outputText.Add(currentLine);

        return outputText;
    }

    public void LoadText( string language)
    {
        _gameText.Clear();
        TextAsset textFile = Resources.Load("languages/" + language + ".txt") as TextAsset;
        List<string> textList = textFile.text.Split("~").ToList();
        foreach(string text in textList)
        {
            List<string> textInfo = text.Split("|").ToList();
            _gameText[int.Parse(textInfo[0])] = textInfo[1];
        }
    }
}
