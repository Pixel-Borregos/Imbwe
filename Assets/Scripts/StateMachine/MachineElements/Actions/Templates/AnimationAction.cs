using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationAction : Action
{
    [Space(10)]
    [Header("Animator")]
    [SerializeField] public Animator animator;

    public override void Reset()
    {
        base.Reset();
        animator = GetComponent<Animator>(); 
    }



}
