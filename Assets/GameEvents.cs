using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;
    public UnityEvent<bool> SwordSwing,Charge;
    private void Awake()
    {
        instance = this;
    }



}
