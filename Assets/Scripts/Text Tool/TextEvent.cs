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
        [Header("Rendering Information")]
        [Tooltip("The maximum amount of characters that the UI element can display by line")]
        [SerializeField] public int maxCharsPerLine;

        [Tooltip("The maximum amount of lines that the UI element can display")]
        [SerializeField] public int maxLines;

        [Tooltip("Id of text to display. If more than one could be displayed add multiple ids.")]
        [SerializeField] public List<int> textIDs;

        [Tooltip("Target UI Element of the this text")]
        [SerializeField] public TextMeshProUGUI textUI;

        [Tooltip("Disable if this is something that needs to be unlocked")]
        [SerializeField] public bool canOcurr = true;
    #endregion


    public void Ocurr()
    {
        if (!canOcurr)
            return;

        canOcurr = false;

        GameObject.Find("TextManager").GetComponent<TextManager>().RenderText(this);
    }
}
