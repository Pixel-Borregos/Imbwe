using System.Collections.Generic;
using UnityEngine;

public class NPCBrain : MonoBehaviour
{
    [Tooltip("Possible Objectives for current NPC when moving")]
    [SerializeField] List<Transform> possibleObjectives;
    [Tooltip("Current Objective")]
    [SerializeField] GameObject originalObjective;
    [SerializeField] int HP;

    public Transform currentObjective;
    public bool alive = true;
    private int currentHP;
    public bool beingAttacked = false;
    
    private void OnEnable()
    {
        RestartNPC();
    }

    void RestartNPC()
    {
        currentHP = HP;
        currentObjective = originalObjective.transform;
        alive = true;
    }

    public  void DamageObjective(int damage)
    {
        try
        {
            originalObjective.GetComponent<NPCBrain>().GetDamage(damage);
        }catch
        {
            originalObjective.GetComponent<PlayerBrain>().isFighting = false;
        }
    }
    public void GetDamage(int damage)
    {
        currentHP -= damage;
    }

    public void SetObjectiveByName(string objective)
    {
        currentObjective = GameObject.Find(objective).transform;
    }
}
