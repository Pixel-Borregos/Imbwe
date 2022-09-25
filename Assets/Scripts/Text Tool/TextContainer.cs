using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TextContainer 
{
    private Dictionary<int, string> _gameText;

    public TextContainer(string language)
    {
        this._gameText = new Dictionary<int, string>();
        LoadText(language);
    }
    public void LoadText(string language)
    {
        _gameText.Clear();
        TextAsset textFile = Resources.Load("languages/" + language ) as TextAsset;
        List<string> textList = textFile.text.Split("~").ToList();
        foreach (string text in textList)
        {
            if (!text.Contains("|"))
                continue;

            List<string> textInfo = text.Split("|").ToList();
            _gameText[int.Parse(textInfo[0])] = textInfo[1];
        }
    }

    public string GetText(int id)
    {
        return _gameText[id];
    }
}
