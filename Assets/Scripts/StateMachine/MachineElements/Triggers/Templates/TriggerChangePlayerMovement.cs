using System.Collections.Generic;
using UnityEngine;

public class TriggerChangePlayerMovement : Trigger
{
    [SerializeField] KeyCode key;
    List<KeyCode> keys = new List<KeyCode>()
    {
        KeyCode.W,
        KeyCode.S,
        KeyCode.A,
        KeyCode.D
    };

    public override bool IsTriggerActive()
    {
        return Input.GetKey(key) && !IsAnotherKeyPressed();
    }

    private bool IsAnotherKeyPressed()
    {
        List<KeyCode> tempKeys = keys.FindAll(k =>{
            return k != key;
        });

        bool firstPressed = Input.GetKey(tempKeys[0]);
        bool secondPressed = Input.GetKey(tempKeys[1]);
        bool thirdPressed = Input.GetKey(tempKeys[2]);
        return firstPressed || secondPressed || thirdPressed;
    }
}
