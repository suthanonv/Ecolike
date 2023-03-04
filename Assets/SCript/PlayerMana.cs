using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    public static PlayerMana instance;
    [SerializeField] PlayerStat stat;
    [SerializeField] StateType type;
     
    [SerializeField] float ManaRegenTIme;
    [SerializeField] int ManaRegenMuch;
    private void Awake()
    {
        instance = this;
    }

    
    public float CurrentMana;

    public void DecreasedMana(int ManaAdd)
    {
        CurrentMana -= ManaAdd;
        UiManager.instance.SetManaValue(stat.GetState(type).Stat, CurrentMana);
    }

    private void Start()
    {
        CurrentMana = stat.GetState(type).Stat;
        UiManager.instance.SetManaValue(stat.GetState(type).Stat, CurrentMana);
        StartCoroutine(RegenMana());
    }

    IEnumerator RegenMana()
    {
        while(true)
        {
            yield return new WaitForSeconds(ManaRegenTIme);
            if(CurrentMana < stat.GetState(type).Stat)
            {
                CurrentMana += ManaRegenMuch;
                UiManager.instance.SetManaValue(stat.GetState(type).Stat, CurrentMana);
                if(CurrentMana >= stat.GetState(type).Stat)
                {
                    CurrentMana = stat.GetState(type).Stat;
                    UiManager.instance.SetManaValue(stat.GetState(type).Stat, CurrentMana); 
                }
            }
        }
    }
   

}
