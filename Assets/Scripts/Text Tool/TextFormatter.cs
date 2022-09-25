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

    public List<string> GetOutputText( TextEvent textEvent )
    {
        string fullOutputText = _textContainer.GetText(textEvent.textIDs[UnityEngine.Random.Range(0,textEvent.textIDs.Count)]);
        return (fullOutputText.Contains("+")) 
            ? fullOutputText.Split("+").ToList() 
            : new List<string>() { fullOutputText };
    }
}
