using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : StateMachineAction
{
    [Header("References")]
    [SerializeField] public Animator animator;
    [SerializeField] public Camera playerCamera;
}
