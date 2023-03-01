using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChangeing : MonoBehaviour
{
    public static WeaponChangeing instance;
    [SerializeField] List<Element> EmUse = new List<Element>();
  public  List<Element> InUse = new List<Element>();
    [SerializeField] SetKeyBinding key;
    int Key1Value, Key2Value, Key3Value;
    float CurrentSwapCD;
    [SerializeField] float SwapCd;
    Element CurrentEM;
     public  Element CurrnetWeapon;
    [SerializeField] Transform WeaponPoint;
    int lastIndex = 0;
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
        if(Input.GetKeyDown(key.ForgeKey))
        {
            if (CurrnetWeapon != CurrentEM)
            {
                CurrnetWeapon = CurrentEM;
                SetHandlleWeapon();
            }
            else
            {
                InUse = new List<Element>();
                UiManager.instance.SetElmenetOnFreame(InUse);
            }
        }
    }


    public void SetHandlleWeapon()
    {
        InUse = new List<Element>();
        UiManager.instance.SetElmenetOnFreame(InUse);
        WeaponPoint.transform.GetChild(lastIndex).gameObject.SetActive(false);
        WeaponPoint.transform.GetChild(CurrnetWeapon.MeleeWeaponNum).gameObject.SetActive(true);
        lastIndex = CurrnetWeapon.MeleeWeaponNum;
       /* foreach (Transform i in WeaponPoint)
        {
            Destroy(i.gameObject);
        }
        Instantiate(CurrnetWeapon.WeaponPrefab, WeaponPoint.transform); */
    }




    void SetElment()
    {
        if (CurrentSwapCD <= 0)
        {
            if (Input.GetKeyDown(key.Em1Key) && Key1Value == 0)
            {
                Key1Value = 1;
                InUse.Add(EmUse[0]);
                UiManager.instance.SetElmenetOnFreame(InUse);
                CurrentSwapCD = SwapCd;
            }
            else if (Input.GetKeyDown(key.Em2Key) && Key2Value == 0)
            {
                Key2Value = 1;
                InUse.Add(EmUse[1]);
                UiManager.instance.SetElmenetOnFreame(InUse);
                CurrentSwapCD = SwapCd;
            }
            else if (Input.GetKeyDown(key.Em3Key) && Key3Value == 0)
            {
                Key3Value = 1;
                InUse.Add(EmUse[2]);
                UiManager.instance.SetElmenetOnFreame(InUse);
                CurrentSwapCD = SwapCd;
            }


            else if (Input.GetKeyDown(key.Em1Key) && Key1Value != 0)
            {
                Key1Value = 0;

                InUse.Remove(EmUse[0]);
                UiManager.instance.SetElmenetOnFreame(InUse);
                CurrentSwapCD = SwapCd;

            }
            else if (Input.GetKeyDown(key.Em2Key) && Key2Value != 0)
            {
                Key2Value = 0;

                InUse.Remove(EmUse[1]);
                UiManager.instance.SetElmenetOnFreame(InUse);
                CurrentSwapCD = SwapCd;
            }
            else if (Input.GetKeyDown(key.Em3Key) && Key3Value != 0)
            {
                Key3Value = 0;

                InUse.Remove(EmUse[2]);
                UiManager.instance.SetElmenetOnFreame(InUse);
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
            UiManager.instance.SetElementSkillSprite(SwapCamera.instance.swap, CurrentEM);
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
        Key1Value = 0;
        Key2Value = 0;
        Key3Value = 0;
        shooting.instance.CurrentEM = CurrnetWeapon;
        UiManager.instance.SetElementSkillSprite(SwapCamera.instance.swap, shooting.instance.CurrentEM);
        SetWeaponColor.instance.SetColor(CurrnetWeapon.Value);
        shooting.instance.MaxGate = CurrnetWeapon.MaxChargeTime;
        shooting.instance.CancelGage();

    }

}
