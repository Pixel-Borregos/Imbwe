using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextEventManager : MonoBehaviour
{
    public float textSpeed;

    public string language;

    private TextFormatter textFormatter;

    public bool renderNewLine = true;

    // Start is called before the first frame update
    void Start()
    {
        textFormatter = new TextFormatter("en");  
    }

    public IEnumerator RenderText(TextEvent textEvent)
    {

        List<string> outputText = textFormatter.GetOutputText(textEvent);

        textEvent.textUI.gameObject.SetActive(true);
        foreach (string output in outputText)
        {
            textEvent.textUI.text = "";

            foreach (char c in output)
            {
                yield return new WaitForSecondsRealtime(textSpeed);
                textEvent.textUI.text += c;
            }

            while (!Input.GetKey(KeyCode.E))
            {
                yield return new WaitForSeconds(0);
            }
        }
        textEvent.textUI.gameObject.SetActive(false);
    }    
}
