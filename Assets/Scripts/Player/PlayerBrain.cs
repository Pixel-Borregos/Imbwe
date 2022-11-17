using System.Collections;
using UnityEngine;

public class PlayerBrain : MonoBehaviour
{
    public bool isFighting;
    public Transform talkingTo;
    public bool startedInteraction = false;
    public bool canBeDamaged = true;
    public bool canAttack = true;

    public IEnumerator Cooldown()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        canAttack = true;
    }
}
