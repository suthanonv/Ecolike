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
 

    [Header("Melee Weapon")]
    public int MeleeWeaponNum;
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
    public projectileRequimrent UtimateProjectile;
    public float UtimateUpTime;
    public float MaxChargeTime;

    [Header("Melee Skill")]
    public int MeleeSkillManaCost;
    public Sprite MeleeSkillImg;
    public GameObject MeleeSkillPrefab;
    public projectileRequimrent MeProjectileCheck;
    public float MeleeSkillCooldown;
    public float CurrentMeleeSkillCooldown;
    
    [Header("Magic Skill")]
    public int MagicSkillManaCost;
    public Sprite MagicSkilImg;
    public GameObject MagicSkillPrefab;
    public projectileRequimrent MgProjectileCheck;
    public float MagicSkillCooldown;
    public float CurrentMagicSkillCooldown;

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

[System.Serializable]
public class projectileRequimrent
{
    public bool isProjectile;
    public float Force;
    public float projectileUptime;
}


