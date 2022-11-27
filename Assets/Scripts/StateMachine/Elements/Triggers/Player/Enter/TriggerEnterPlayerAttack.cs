using UnityEngine;

public class TriggerEnterPlayerAttack : Trigger
{
    public override bool IsTriggerActive()
    {
        return Input.GetAxis("Fire1") != 0 && GetComponent<PlayerBrain>().canAttack;
    }
}
