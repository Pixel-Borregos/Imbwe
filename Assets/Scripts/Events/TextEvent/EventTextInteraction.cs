using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;


public class EventTextInteraction : MonoBehaviour
{
    [Tooltip("Target UI Element of the this text")]
    [SerializeField] 
    TextMeshProUGUI textUI;

    [Tooltip("List of dialogues per state in the story")]
    [SerializeField] 
    List<TextEventInformation> textEventInformationList;


    public TextEventManager textEventManager;

    private void OnEnable()
    {
        if(textEventManager == null)
            textEventManager = GameObject.Find("TextManager").GetComponent<TextEventManager>();
    }

    public void Ocurr()
    {
        if (!textEventManager.canStartEvent)
            return;

        textEventManager.canStartEvent = false;

        //se debe de actualizar a que el world state manager le diga que se le manda al text tool
        StartCoroutine(
            textEventManager.RenderText(textEventInformationList[0],textUI)
        );
       
    }
}
