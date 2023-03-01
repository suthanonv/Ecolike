using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum ElementType
{ 
 less,fire,water,earth
}

[CreateAssetMenu]
public class ElementalBaseDamageStat : ScriptableObject
{
    public List<ElementBaseStat> AllElementalBaseStat = new List<ElementBaseStat>();

   

   public ElementBaseStat GetBaseDamage(ElementType GetType)
    {
        ElementBaseStat stat =  AllElementalBaseStat.FirstOrDefault(i => i.type == GetType);

        if(stat.CurrentBaseDamage == 0)
        {
            stat.CurrentBaseDamage = stat.baseDamage;
        }

        return stat;
    }

}


[System.Serializable]
public class ElementBaseStat
{
    public ElementType type;
    public float baseDamage;
    public float CurrentBaseDamage;
}




