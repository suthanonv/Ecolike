using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class SettingKeyUI : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> NameText = new List<TextMeshProUGUI>();
    [SerializeField] List<TextMeshProUGUI> KeyText = new List<TextMeshProUGUI>();
    [SerializeField] List<key> keySeacrh = new List<key>();
    [SerializeField] List<string> Name = new List<string>();
    [SerializeField] SettingKeyBind keybindSet;
    [SerializeField] public UnityEvent OnChange, FinishChnage;
    public void SetKeyByArray(int Num)  
    {
        OnChange.Invoke();
        keybindSet.SetRef(this.gameObject.GetComponent<SettingKeyUI>());
        keybindSet.SetKey(keySeacrh[Num], KeyText[Num]);
    }
}
