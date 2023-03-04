using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum ElementType
{ 
 less,fire,water,earth
}
public  enum EffectTypechance
{ 
    all,water,fire,earth,less
}

[CreateAssetMenu]
public class ElementalBaseDamageStat : ScriptableObject
{
    public List<ElementBaseStat> AllElementalBaseStat = new List<ElementBaseStat>();
    public List<EffectChance> AllEffectchange = new List<EffectChance>();
   

   public ElementBaseStat GetBaseDamage(ElementType GetType)
    {
        ElementBaseStat stat =  AllElementalBaseStat.FirstOrDefault(i => i.type == GetType);

        return stat;
    }


    public EffectChance GetEffect(EffectTypechance type)
    {
        return AllEffectchange.FirstOrDefault(i => i.type == type);
    }

}


[System.Serializable]
public class ElementBaseStat
{
    public ElementType type;
    public float baseDamage;
}
[System.Serializable]
public class EffectChance
{
    public EffectTypechance type;
    public float chance;
    public Reaction EffectPrefab;
}




