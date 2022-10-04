using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionAlwaysTrue : Condition
{

    public override bool IsConditionMet()
    {
        return true;
    }
}
