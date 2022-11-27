using UnityEngine;

public class TriggerEnterPlayerRoll : Trigger
{

    public override bool IsTriggerActive()
    {
        return Input.GetAxis("Roll") != 0;
    }
}
