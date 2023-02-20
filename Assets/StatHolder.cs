using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHolder : MonoBehaviour
{
    public BaseStat CharacterBaseStat;
    public DebuffStat BaseDebuffStat;
    public BaseDamaegStat BaseCharacterDamage;
}

[System.Serializable]

public struct BaseStat
{
    public float MaxHp;
    public float MaxMana;
    public float MaxSpeed;
    public float CurentSpeed;
}
[System.Serializable]
public struct BaseDamaegStat
{
    public float BaseMeleeDamage;
    public float CurrentBaseMeleeDamage;
    public List<float> BaseSkillDamage;
    public List<float> CurrentBaseSkillDamage;
    public float BaseUltimateDamage;
    public float CurrentBaseUltimateDamage;
}

[System.Serializable]
public struct DebuffStat
{
    public float DamageMultiple;
    public float MaxKncokBackForce;
    public float CurrentKncokBackTime;
    public float MaxStudingTime;
    public float CurrentStudneingTIme;
}
