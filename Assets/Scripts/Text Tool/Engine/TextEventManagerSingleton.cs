using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This class can be used to manage single linear text events
/// and display them on a target UI element.
/// 
/// 
/// For more information please read the documentation.
/// 
/// 
/// </summary>
public class TextEventManagerSingleton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textUI;
    public float textSpeed;
    public string language;
    private TextFormatter textFormatter;
    public bool renderNewLine = true;
    public bool canStartEvent = true;

    private static TextEventManagerSingleton _instance;


    public static TextEventManagerSingleton GetInstance()
    {
        if (_instance == null)
        {
            throw new System.NullReferenceException("You are trying to access a nonexistent TextEventManagerSingleton");
        }
        return _instance;
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Debug.LogWarning("There is already an instance of TextEventManagerSingleton in the scene ");
            Destroy(this);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        textFormatter = new TextFormatter(language);  
    }

    public IEnumerator RenderText(TextEventInformation textEvent)
    {
        UIManagerSingleton.GetInstance().ChangeGameModeUI(1);
        List<string> outputText = textFormatter.GetOutputText(textEvent.textIDs);

        textUI.gameObject.SetActive(true);
        foreach (string output in outputText)
        {
            textUI.text = "";

            foreach (char c in output)
            {
                yield return new WaitForSecondsRealtime(textSpeed);
                textUI.text += c;
                if (Input.GetKey(KeyCode.Escape))
                {
                    textUI.gameObject.SetActive(false);
                    canStartEvent = true;
                    UIManagerSingleton.GetInstance().ChangeGameModeUI(0);
                    break;
                }
                if (Input.GetKey(KeyCode.R))
                {
                    textUI.text = output;
                    break;
                }
            }
            if (canStartEvent)
                break;

            while (!Input.GetKey(KeyCode.E))
            {
                yield return new WaitForSeconds(0);
                if (Input.GetKey(KeyCode.Escape))
                {
                    textUI.gameObject.SetActive(false);
                    canStartEvent = true;
                    UIManagerSingleton.GetInstance().ChangeGameModeUI(0);
                    break;
                }

            }
            if (canStartEvent)
                break; 
        }
        textUI.gameObject.SetActive(false);
        canStartEvent = true;
        UIManagerSingleton.GetInstance().ChangeGameModeUI(0);
    }    
}
