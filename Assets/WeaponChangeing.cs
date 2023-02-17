using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChangeing : MonoBehaviour
{
    public static WeaponChangeing instance;
    [SerializeField] List<Element> EmUse = new List<Element>();
  public  List<Element> InUse = new List<Element>();
    public KeyCode Em1Key = KeyCode.Q;
    public KeyCode Em2Key = KeyCode.E;
    public KeyCode Em3Key = KeyCode.R;
    public KeyCode ForgeKey = KeyCode.H;
    int Key1Value, Key2Value, Key3Value;
    float CurrentSwapCD;
    [SerializeField] float SwapCd;
    Element CurrentEM;
  public  Element CurrnetWeapon;
    [SerializeField] Transform WeaponPoint;

    private void Awake()
    {
        instance = this;

    }

    private void Start()
    {
        CurrentEM = ElementManage.instance.GetEmByRequire(InUse);
        CurrnetWeapon = CurrentEM;
        SetHandlleWeapon();
    }

    private void Update()
    {
        SetElment();
        SetWeapon();
    }
    void SetWeapon()
    {
        if(Input.GetKeyDown(ForgeKey))
        {
            if(CurrnetWeapon != CurrentEM)
            {
                CurrnetWeapon = CurrentEM;
                SetHandlleWeapon();
            }
        }
    }


    public void SetHandlleWeapon()
    { 
        foreach(Transform i in WeaponPoint)
        {
            Destroy(i.gameObject);
        }
        Instantiate(CurrnetWeapon.WeaponPrefab, WeaponPoint.transform);
    }




    void SetElment()
    {
        if (CurrentSwapCD <= 0)
        {
            if (Input.GetKeyDown(Em1Key) && Key1Value == 0)
            {
                Key1Value = 1;
                InUse.Add(EmUse[0]);
                CurrentSwapCD = SwapCd;
            }
            else if (Input.GetKeyDown(Em2Key) && Key2Value == 0)
            {
                Key2Value = 1;
                InUse.Add(EmUse[1]);

                CurrentSwapCD = SwapCd;
            }
            else if (Input.GetKeyDown(Em3Key) && Key3Value == 0)
            {
                Key3Value = 1;
                InUse.Add(EmUse[2]);
                CurrentSwapCD = SwapCd;
            }


            else if (Input.GetKeyDown(Em1Key) && Key1Value != 0)
            {
                Key1Value = 0;

                InUse.Remove(EmUse[0]);
                CurrentSwapCD = SwapCd;

            }
            else if (Input.GetKeyDown(Em2Key) && Key2Value != 0)
            {
                Key2Value = 0;

                InUse.Remove(EmUse[1]);
                CurrentSwapCD = SwapCd;
            }
            else if (Input.GetKeyDown(Em3Key) && Key3Value != 0)
            {
                Key3Value = 0;

                InUse.Remove(EmUse[2]);
                CurrentSwapCD = SwapCd;
            }
        }
        else
        {
            CurrentSwapCD -= Time.deltaTime;
        }

        if (CurrentEM != ElementManage.instance.GetEmByRequire(InUse))
        {
            CurrentEM = ElementManage.instance.GetEmByRequire(InUse);
        }
    }

    private void OnDisable()
    {
        if (InUse.Count > 0)
        {
            shooting.instance.InUse = this.InUse;
        }
        else
        {
            shooting.instance.InUse = new List<Element>();
        }
        shooting.instance.CurrentEM = CurrnetWeapon;
        shooting.instance.Key1Value = CurrnetWeapon.RequireKey[0];
        shooting.instance.Key2Value = CurrnetWeapon.RequireKey[1];
        shooting.instance.Key3Value = CurrnetWeapon.RequireKey[2];
    }

}
