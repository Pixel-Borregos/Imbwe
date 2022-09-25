using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextEvent : MonoBehaviour
{
    /*
     * Attach this class to any game object that needs to render text.
     * 
     * 
     */
    #region Serialized Fields

    [Tooltip("Id of text to display. If more than one could be displayed add multiple ids.")]
    [SerializeField] public List<int> textIDs;

    [Tooltip("Target UI Element of the this text")]
    [SerializeField] public TextMeshProUGUI textUI;

    [Tooltip("Text Event Manager")]
    [SerializeField] TextEventManager textEventManager;

    bool canOcurr = true;
    #endregion


    public void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
            Ocurr();
    }
    public void Ocurr()
    {
        if (!canOcurr)
            return;

        canOcurr = false;

        StartCoroutine(
            textEventManager.RenderText(this)
        );

        canOcurr = true;
    }
}
