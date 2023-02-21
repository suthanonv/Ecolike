using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Element : ScriptableObject
{   
    [Header("Effect")]
    public Color ElementColor;
    public AudioClip CastingSound;
    public GameObject ElementFreame;
    [Header("Costing And Value")]
    public int Value;
    public ElementType TypeOfElement;
    public List<int> RequireKey = new List<int>();
    public List<RequireElment> AllRequire = new List<RequireElment>();
    public int ManaCost;
    public int UltimateManaCost;
    [Header("Prefab")]
    public GameObject ElementPrefab;
    public GameObject UltimatePrefab;

    [Header("Melee Weapon")]
    public GameObject WeaponPrefab;
    public GameObject MeleePrefab;
    public GameObject MeleeUlti;
    public float MeleeUltiChargeTime;
    public float MeleeAttackCD;

    [Header("Normle Attack Stat")]
    
    public float AttackCD;
    public float Force;
    public bool isProjectile;
    public float BulletUpTime;

    [Header("Ultimate Stat")]
    public bool isUtimateProjectile;
    public float UltiForce;
    public float UtimateUpTime;
   public float MaxChargeTime;

    [Header("Element Reaction")]
    public List<ElmentReaction> possiblereact = new List<ElmentReaction>();
    public GameObject ReactionFream;
}

[System.Serializable]
public class RequireElment
{
    public List<Element> RequiredEM = new List<Element>();
}

[System.Serializable]
public class ElmentReaction { 

    public int Value;
    public GameObject ReactPrefab;
}


