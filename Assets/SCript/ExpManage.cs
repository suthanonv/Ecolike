using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpManage : MonoBehaviour
{
    public static ExpManage instance;

    int currentlv = 1;
    float lastExp = 99;
    float MaxExp;
    float currentExp;

    private void Start()
    {
        MaxExp = GetNextLv();
        UiManager.instance.SetNewExpBar(MaxExp, currentExp);
    }

    float GetNextLv()
    {
        float requireExp = currentlv + (currentlv * lastExp);
        return requireExp;
    }

    public void GainExp(float gainMuch)
    {
        currentExp += gainMuch;
        if(currentExp >= MaxExp)
        {
            currentExp -= MaxExp;
            lastExp = MaxExp;
            MaxExp = GetNextLv();
            currentlv++;
        }
        UiManager.instance.SetNewExpBar(MaxExp, currentExp);
    }

}
