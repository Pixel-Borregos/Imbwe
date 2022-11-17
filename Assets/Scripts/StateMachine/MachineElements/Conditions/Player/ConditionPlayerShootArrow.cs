using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionPlayerShootArrow : Condition
{
    public override bool IsConditionMet()
    {
        return Input.GetAxis("Fire1") == 0;
    }
}
