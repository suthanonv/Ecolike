using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    public static PlayerMana instance;


    private void Awake()
    {
        instance = this;
    }

    public int Mana;
    public int CurrentMana;

    private void Start()
    {
        CurrentMana = Mana;
    }


}
