using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;


public class EventTextInteraction : MonoBehaviour
{
    [Tooltip("List of dialogues per state in the story")]
    [SerializeField] 
    List<TextEventInformation> textEventInformationList;

    public void Ocurr()
    {

        TextEventManagerSingleton textManager = TextEventManagerSingleton.GetInstance();
        if (!textManager.canStartEvent)
            return;

        textManager.canStartEvent = false;

        //se debe de actualizar a que el world state manager le diga que se le manda al text tool
        StartCoroutine(
            textManager.RenderText(textEventInformationList[0])
        );
    }

   
}
