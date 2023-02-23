using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class StatHolder : MonoBehaviour
{
    public BaseStat CharacterBaseStat;
    public DebuffStat BaseDebuffStat;
    public BaseDamaegStat BaseCharacterDamage;
    public List<Resistance> BaseResistance;

    public float GetResistance(ElementType GetType)
    {
        float resistance =  BaseResistance.FirstOrDefault(i => i.typeOfResis == GetType).ResistantAmount;

        if(resistance <= 0)
        {
            return 1 + resistance * -1;
        }
        else if(resistance < 1)
        {
            return resistance;
        }
        else
        {
            return 0;
        }

    }
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

[System.Serializable]
public struct Resistance
{
    public ElementType typeOfResis;
    public float ResistantAmount;
}

