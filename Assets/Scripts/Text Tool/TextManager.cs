using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public float textSpeed;

    public string language;

    private TextFormatter textFormatter;

    public bool renderNewLine;

    // Start is called before the first frame update
    void Start()
    {
        renderNewLine = true;
        textFormatter = new TextFormatter(language);
    }

    public IEnumerator RenderText(TextEvent textEvent)
    {
        List<string> outputText = textFormatter.GetOutputText(textEvent);

        foreach (string output in outputText)
        {
            textEvent.textUI.text = "";

            foreach (char c in output)
            {
                yield return new WaitForSecondsRealtime(textSpeed);
                textEvent.textUI.text += c;
            }

            renderNewLine = false;

            while (!renderNewLine)
                continue;
        }
    }

    public void EnableRenderNewLine()
    {
        renderNewLine = true;
    }

    
}
