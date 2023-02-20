using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class shooting : MonoBehaviour
{
    public static shooting instance;
    public KeyCode shootKey = KeyCode.Mouse0;
    public KeyCode ForgeKey = KeyCode.H;
    public KeyCode Em1Key = KeyCode.Q;
    public KeyCode Em2Key = KeyCode.E;
    public KeyCode Em3Key = KeyCode.R;

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
        if (Input.GetKeyDown(ForgeKey))
        {
            SetSum();
        }
        //ChargedUltimate();
    }
    bool Charge;
    void ChargedUltimate()
    {

        if(Charge == false)
        {
            Slider.SetActive(false);
            PlayerWalk.instance.OnSlow(false);
        }
        else
        {
            Slider.SetActive(true);
        }


        if (Charge && CurrentGage < MaxGate)
        {
            PlayerWalk.instance.OnSlow(false);
            CurrentGage = Mathf.Lerp(CurrentGage, MaxGate +1, Time.deltaTime * CastingSpeed);
        }
        if(CurrentGage >= MaxGate)
        {
            PlayerWalk.instance.OnSlow(false);
            CurrentGage = MaxGate;
        }
        UltimateGage.value = CurrentGage;
    }

    public void CancelGage()
    {
        InUse = new List<Element>();
        UiManager.instance.SetElmenetOnFreame(InUse);
    }

    void ShootingElement()
    {
        if (CurrentCD <= 0)
        {
            if (Input.GetKey(shootKey))
            {
                PlayerWalk.instance.OnSlow(true);
                CurrentGage = Mathf.Lerp(CurrentGage, MaxGate + 1, Time.deltaTime * CastingSpeed);
                UltimateGage.value = CurrentGage;
                Slider.SetActive(true);
            }
            if(Input.GetKeyUp(shootKey))
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
            if (Input.GetKeyDown(Em1Key) && Key1Value == 0)
            {
                Key1Value = 1;
                InUse.Add(EmUse[0]);
                UiManager.instance.SetElmenetOnFreame(InUse);
                CurrentSwapCD = SwapCd;
            }
          else  if (Input.GetKeyDown(Em2Key) && Key2Value == 0)
            {
                Key2Value = 1;
                InUse.Add(EmUse[1]);
                UiManager.instance.SetElmenetOnFreame(InUse);
                CurrentSwapCD = SwapCd;
            }
            else if (Input.GetKeyDown(Em3Key) && Key3Value == 0)
            {
                Key3Value = 1;
                InUse.Add(EmUse[2]);
                UiManager.instance.SetElmenetOnFreame(InUse);
                CurrentSwapCD = SwapCd;
            }


            else if (Input.GetKeyDown(Em1Key) && Key1Value != 0)
            {
                Key1Value = 0;
 
                InUse.Remove(EmUse[0]);
                UiManager.instance.SetElmenetOnFreame(InUse);
                CurrentSwapCD = SwapCd;

            }
            else if (Input.GetKeyDown(Em2Key) && Key2Value != 0)
            {
                Key2Value = 0;
                InUse.Remove(EmUse[1]);
                UiManager.instance.SetElmenetOnFreame(InUse);
                CurrentSwapCD = SwapCd;
            }
            else if (Input.GetKeyDown(Em3Key) && Key3Value != 0)
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
    }
   

}
