using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BuffAura : MonoBehaviour
{
    [SerializeField] ElementalBaseDamageStat state;
    [SerializeField] float BuffAmount;
    [SerializeField] float MainStateBuffAmount;
    [SerializeField] ElementType type;
    [SerializeField] UnityEvent call;
    List<float> DamageSave;
   
    private void OnEnable()
    {
        DamageSave = new List<float>();
      foreach(ElementBaseStat s in state.AllElementalBaseStat)
        {
            if(s.type == type)
            {
                float DamageIncrease = s.baseDamage * (MainStateBuffAmount / 100);
                DamageSave.Add(DamageIncrease);
                s.baseDamage += DamageIncrease;
            }
            else
            {
                float DamageIncrease = s.baseDamage * (BuffAmount / 100);
                DamageSave.Add(DamageIncrease);
                s.baseDamage += DamageIncrease;
            }
        }
    }

    public void SetDamage()
    {
        call.Invoke();
    }

    private void OnDisable()
    {
        int count = 0;
        foreach(ElementBaseStat s in state.AllElementalBaseStat)
        {
            s.baseDamage -= DamageSave[count];
            count++;
        }
    }
}
