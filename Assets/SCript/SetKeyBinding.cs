using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum key
{ 
Attack,WeaponSkill,ElementSkill,Em1,Em2,Em3,Forge,SwapKey
}

[CreateAssetMenu]

public class SetKeyBinding : ScriptableObject
{
    public KeyCode AttackKey = KeyCode.Mouse0;
    public KeyCode WeapoNSkillKey = KeyCode.F;
    public KeyCode ElementSKillKey = KeyCode.G;
    public KeyCode Em1Key = KeyCode.Q;
    public KeyCode Em2Key = KeyCode.E;
    public KeyCode Em3Key = KeyCode.R;
    public KeyCode ForgeKey = KeyCode.X;
    public KeyCode SwapKey = KeyCode.Z;

    public void loadnewKeyBind()
    {
        if(UiManager.instance != null)
        {
            UiManager.instance.SetKeyText();
        }
    }

    public void SetToDefault()
    {
        AttackKey = KeyCode.Mouse0;
        WeapoNSkillKey = KeyCode.F;
        ElementSKillKey = KeyCode.G;
        Em1Key = KeyCode.Q;
        Em2Key = KeyCode.E;
        Em3Key = KeyCode.R;
        ForgeKey = KeyCode.X;
        SwapKey = KeyCode.Z;
        loadnewKeyBind();
    }

    public void changeKeyBind(key keylist,KeyCode newkey)
    {
        if(keylist == key.Attack)
        {
            AttackKey = newkey;
        }
        else if(keylist == key.WeaponSkill)
        {
            WeapoNSkillKey = newkey;
        }
        else if(keylist == key.ElementSkill)
        {
            ElementSKillKey = newkey;
        }
        else if(keylist == key.Em1)
        {
            Em1Key = newkey;
        }
        else if(keylist == key.Em2)
        {
            Em2Key = newkey;
        }
        else if(keylist == key.Em3)
        {
            Em3Key = newkey;
        }
        else if(keylist == key.Forge)
        {
            ForgeKey = newkey;
        }
        else if(keylist == key.SwapKey)
        {
            SwapKey = newkey;
        }
        loadnewKeyBind();
    }
}
