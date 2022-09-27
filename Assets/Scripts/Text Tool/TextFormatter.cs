using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TextFormatter 
{

    private TextContainer _textContainer;

    public TextFormatter( string language)
    {
        _textContainer = new TextContainer(language);
    }

    public List<string> GetOutputText( List<int> textIDs)
    {
        string fullOutputText = _textContainer.GetText(textIDs[UnityEngine.Random.Range(0,textIDs.Count)]);
        return (fullOutputText.Contains("+")) 
            ? fullOutputText.Split("+").ToList() 
            : new List<string>() { fullOutputText };
    }
}
