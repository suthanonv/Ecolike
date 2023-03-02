using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class shooting : MonoBehaviour
{
    public static shooting instance;
    [SerializeField] SetKeyBinding key;

 public   int Key1Value, Key2Value, Key3Value;
     int ManaRequire;
    
    [SerializeField] float ShootCD;
  float   CurrentCD;
    [SerializeField] float SwapCd = 0.1f;

    [SerializeField] List<Element> EmUse = new List<Element>();
    [SerializeField] public List<Element> InUse;

    float CurrentSwapCD;
    public int sum;
    bool CanSwape;

    [Header("Ultimate Slider")]
    [SerializeField] Slider UltimateGage;
  public  Element CurrentEM;
    float  CurrentGage;
   public float MaxGate;
    [SerializeField] float CastingSpeed = 1;
    [SerializeField] GameObject Slider;
    
    private void Awake()
    {
        instance = this;
        Slider.SetActive(false);
    }

    private void Update()
    {
        SetElment();
        ShootingElement();
        if (Input.GetKeyDown(key.ForgeKey))
        {
            SetSum();
        }
        //ChargedUltimate();
    }
  
    public void CancelGage()
    {
        CurrentGage = 0;
        InUse = new List<Element>();
        UiManager.instance.SetElmenetOnFreame(InUse);
    }

    void ShootingElement()
    {
        if (CurrentCD <= 0)
        {
            if (Input.GetKey(key.AttackKey))
            {
                PlayerWalk.instance.OnSlow(true);
                CurrentGage = Mathf.Lerp(CurrentGage, MaxGate + 1, Time.deltaTime * CastingSpeed);
                UltimateGage.value = CurrentGage;
                Slider.SetActive(true);
            }
            if(Input.GetKeyUp(key.AttackKey))
            {
                ReleaseElement();
                PlayerWalk.instance.OnSlow(false);
            }
        }
        else
        {
            CurrentCD -= Time.deltaTime;
        }
    }

    

  public  void SetSum()
    {
        
   
        if (CurrentEM != ElementManage.instance.GetEmByRequire(InUse))
        {
            SetWeaponColor.instance.SetColor(ElementManage.instance.GetEmByRequire(InUse).Value);
            CurrentEM = ElementManage.instance.GetEmByRequire(InUse);
            CancelGage();
            CurrentCD = 0;
             CurrentGage = 0;
            MaxGate = CurrentEM.MaxChargeTime;
            UltimateGage.maxValue = MaxGate;
        }
        else
        {
            CancelGage();
        }
    }

    void ReleaseElement()
    {
        if (CanRelease())
        {
            if (CurrentGage < MaxGate)
            {
                ElementManage.instance.ReleaseEM(CurrentEM);
                CurrentCD = CurrentEM.AttackCD;
            }
            else
            {
                ElementManage.instance.ReleaseUtimate(CurrentEM);
            }
        }
        else
        {
            Debug.Log("not Enought Mana");
        }
        UltimateGage.value = CurrentGage;
        CurrentGage = 0;
        CurrentCD = CurrentEM.AttackCD;
        Slider.SetActive(false);
    }

    bool CanRelease()
    {
        
            ManaRequire = CurrentEM.ManaCost;

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
          else  if (Input.GetKeyDown(key.Em2Key) && Key2Value == 0)
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
    }

    private void OnDisable()
    {
        Slider.SetActive(false);
        CurrentGage = 0;
        if (this.CurrentEM == null)
        {
            WeaponChangeing.instance.CurrnetWeapon = ElementManage.instance.GetEm(0);
            WeaponChangeing.instance.SetHandlleWeapon();
        }
        else
        {
            WeaponChangeing.instance.CurrnetWeapon = this.CurrentEM;
            WeaponChangeing.instance.SetHandlleWeapon();
        }
        UiManager.instance.SetElementSkillSprite(SwapCamera.instance.swap, WeaponChangeing.instance.CurrnetWeapon);
        Key1Value = 0;
        Key2Value = 0;
        Key3Value = 0;
    }
   
    
}
