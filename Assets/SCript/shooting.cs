using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class shooting : MonoBehaviour
{
    public static shooting instance;
    public KeyCode shootKey = KeyCode.Mouse0;
    public KeyCode Em1Key = KeyCode.Q;
    public KeyCode Em2Key = KeyCode.E;
    public KeyCode Em3Key = KeyCode.R;
    int Key1Value, Key2Value, Key3Value;
    [SerializeField] int ManaRequire;
    
    [SerializeField] float ShootCD;
  float   CurrentCD;
    [SerializeField] float SwapCd = 0.1f;

    [SerializeField] List<Element> EmUse = new List<Element>();
    float CurrentSwapCD;
    public int sum;
    bool CanSwape;
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        SetElment();
        ShootingElement();
        SetSum();
    }

    void ShootingElement()
    {
        if (CurrentCD <= 0)
        {
            if (Input.GetKey(shootKey))
            {
                ReleaseElement();
            }
        }
        else
        {
            CurrentCD -= Time.deltaTime;
        }
    }

    

    void SetSum()
    {
        if ((Key1Value != 0 && Key2Value + Key3Value == 0) || Key2Value != 0 && Key1Value + Key3Value == 0 || Key3Value != 0 && Key1Value + Key2Value == 0)
        {
            sum = Key1Value + Key2Value + Key3Value;
            SetWeaponColor.instance.SetColor(sum);
        }
        else if(Key1Value + Key2Value + Key3Value == 0)
        {
             sum = 0;
            SetWeaponColor.instance.SetColor(sum);
        }
        else

        {
            sum = (Key1Value * Key1Value) + (Key2Value * Key2Value) + (Key3Value * Key3Value);
            
        }
    }

    void ReleaseElement()
    {
        if (CanRelease(sum))
        {
            ElementManage.instance.ReleaseEM(sum);
            ReSetKeyValue();
            CurrentCD = ShootCD;
        }
    }

    bool CanRelease(int value)
    {
        ManaRequire = ElementManage.instance.GetEm(value).ManaCost;
        if (PlayerMana.instance.CurrentMana >= ManaRequire)
        {
            PlayerMana.instance.DecreasedMana(ManaRequire);
            return true;
        }
        else
        {
            return false;
        }
        
    }


    void ReSetKeyValue()
    {
        Key1Value = 0;
        Key2Value = 0;
        Key3Value = 0;
    }
    void SetElment()
    {
        if (CurrentSwapCD <= 0)
        {
            if (Input.GetKeyDown(Em1Key) && Key1Value == 0)
            {
                Key1Value = EmUse[0].Value;
                CurrentSwapCD = SwapCd;
            }
          else  if (Input.GetKeyDown(Em2Key) && Key2Value == 0)
            {
                Key2Value = EmUse[1].Value;
                CurrentSwapCD = SwapCd;
            }
            else if (Input.GetKeyDown(Em3Key) && Key3Value == 0)
            {
                Key3Value = EmUse[2].Value;
                CurrentSwapCD = SwapCd;
            }


            else if (Input.GetKeyDown(Em1Key) && Key1Value != 0)
            {
                Key1Value = 0;
                CurrentSwapCD = SwapCd;

            }
            else if (Input.GetKeyDown(Em2Key) && Key2Value != 0)
            {
                Key2Value = 0;
                CurrentSwapCD = SwapCd;
            }
            else if (Input.GetKeyDown(Em3Key) && Key3Value != 0)
            {
                Key3Value = 0;
                CurrentSwapCD = SwapCd;
            }
        }
        else
        {
            CurrentSwapCD -= Time.deltaTime;
        }
    }
    
}
