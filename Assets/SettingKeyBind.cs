using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class SettingKeyBind : MonoBehaviour
{
    string state;
    [SerializeField] SetKeyBinding keybind;
    key currentkey;
    TextMeshProUGUI newText;
    private void Update()
    {
        if (state == "Start") { 
            foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keycode))
                {
                    state = "";
                    keybind.changeKeyBind(currentkey, keycode);
                    newText.text = keycode.ToString();
                    UI.FinishChnage.Invoke();
                    break;
                }
            }
    }
    }

    public void SetKey(key keyChangeing,TextMeshProUGUI uiChange)
    {
        currentkey = keyChangeing;
        state = "Start";
        newText = uiChange;
        newText.text = "";
    }
    SettingKeyUI UI;
    public void SetRef(SettingKeyUI newUi)
    {
        UI = newUi;
    }
}
