using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    public static PlayerMana instance;
    [SerializeField] float ManaRegenTIme;
    [SerializeField] int ManaRegenMuch;
    private void Awake()
    {
        instance = this;
    }

    public int Mana;
    public int CurrentMana;

    public void DecreasedMana(int ManaAdd)
    {
        CurrentMana -= ManaAdd;
        UiManager.instance.SetManaValue(Mana, CurrentMana);
    }

    private void Start()
    {
        CurrentMana = Mana;
        UiManager.instance.SetManaValue(Mana, CurrentMana);
        StartCoroutine(RegenMana());
    }

    IEnumerator RegenMana()
    {
        while(true)
        {
            yield return new WaitForSeconds(ManaRegenTIme);
            if(CurrentMana < Mana)
            {
                CurrentMana += ManaRegenMuch;
            }
        }
    }
   

}
