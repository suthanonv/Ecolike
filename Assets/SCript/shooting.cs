using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class shooting : MonoBehaviour
{
    public static shooting instance;
    public KeyCode shootKey = KeyCode.Mouse0;
    public KeyCode Em1Key = KeyCode.Q;
    public KeyCode Em2Key = KeyCode.E;
    public KeyCode Em3Key = KeyCode.R;
    public KeyCode ChargedKey = KeyCode.F;
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
    float MaxGate;
    [SerializeField] float CastingSpeed = 1;
    [SerializeField] GameObject Slider;
    
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        SetElment();
        ShootingElement();
        SetSum();
        ChargedUltimate();
    }
    bool Charge;
    void ChargedUltimate()
    {

        if(Input.GetKeyDown(ChargedKey))
        {
            Charge = true;
        } 

        if(Charge == false)
        {
            Slider.SetActive(false);
            WeaponWalking.instance.slowWalk(false);
        }
        else
        {
            Slider.SetActive(true);
        }


        if (Charge && CurrentGage < MaxGate)
        {
            WeaponWalking.instance.slowWalk(true);
            CurrentGage = Mathf.Lerp(CurrentGage, MaxGate +1, Time.deltaTime * CastingSpeed);
        }
        if(CurrentGage >= MaxGate)
        {
            WeaponWalking.instance.slowWalk(false);
            CurrentGage = MaxGate;
        }
        UltimateGage.value = CurrentGage;
    }

    public void CancelGage()
    {
        Charge = false;

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
        
        SetWeaponColor.instance.SetColor(ElementManage.instance.GetEmByRequire(InUse).Value);
       
        if (CurrentEM != ElementManage.instance.GetEmByRequire(InUse))
        {
            CancelGage();
            CurrentGage = 0;
            CurrentEM = ElementManage.instance.GetEmByRequire(InUse);
            MaxGate = CurrentEM.MaxChargeTime;
            UltimateGage.maxValue = MaxGate;
        }
    }

    void ReleaseElement()
    {
        if (CanRelease(sum))
        {
            if (CurrentGage < MaxGate)
            {
                Charge = false;
                CurrentGage = 0;
                ElementManage.instance.ReleaseEM(CurrentEM);
                CurrentCD = CurrentEM.AttackCD;
            }
            else
            {
                Charge = false;
                CurrentGage = 0;
                ElementManage.instance.ReleaseUtimate(CurrentEM);
                CurrentCD = CurrentEM.AttackCD;
            }
        }
        else
        {
            Debug.Log("not Enought Mana");
        }
    }

    bool CanRelease(int value)
    {
        if (CurrentGage < MaxGate)
        {
            ManaRequire = CurrentEM.ManaCost;
        }
        else
        {
            ManaRequire = CurrentEM.UltimateManaCost;
        }
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
                CurrentSwapCD = SwapCd;
            }
          else  if (Input.GetKeyDown(Em2Key) && Key2Value == 0)
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
    }

    private void OnDisable()
    {
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
