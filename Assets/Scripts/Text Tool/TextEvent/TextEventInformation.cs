using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct TextEventInformation
{
    public List<EnumWorldState> targetWorldStates;
    public List<int> textIDs;
    [Tooltip("Select this when you have more than one text in the textIDs list and the texts must not be shown in order")]
    public bool randomizeText;
    
}
