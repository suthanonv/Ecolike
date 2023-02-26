using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    private void Awake()
    {
        instance = this;
    }
    [Header("Health Bar")]
    [SerializeField] Slider HealtSlider;
    [SerializeField] Slider AnimHealthSlider;
    float LastHealth;

    [Header("Mana Bar")]
    [SerializeField] Slider ManaSlider;
    [SerializeField] Slider AnimManaSlider;
    int LastMana;


    [Header("Element Fream")]
    [SerializeField] Transform EmPickUPFreame;
    [SerializeField] GameObject Freame;


    [Header("WeaponBase Skill")]
    [SerializeField] Image BaseCharaterSkillFreme;
    [SerializeField] Image CooldownImage;

    [Header("Key binding Fream")]
    [SerializeField] GameObject ClosePhase;
    [SerializeField] GameObject OpenPhase;

    [Header("Weapon Base Skill Freame")]
    [SerializeField] Image SkillImage;
    [SerializeField] Sprite DashSprite;
    [SerializeField] Sprite ShieldSprite;
    public  Image BaseWeaponCooldown;
    [SerializeField] TextMeshProUGUI coldowntext;

    [Header("Element Skill Freame")]
    [SerializeField] Image ElementSkillImage;
    public Image ElementnCooldown;
    [SerializeField] TextMeshProUGUI Elementcoldowntext;
    public void SetHealthValue(float MaxHealh, float CurrentHealth)
    {
        HealtSlider.maxValue = MaxHealh;
        HealtSlider.value = CurrentHealth;
        RunHealtAnimation(CurrentHealth, MaxHealh);
    }

    public void SetManaValue(int MaxMana, int CurrentMana)
    {
        ManaSlider.maxValue = MaxMana;
        ManaSlider.value = CurrentMana;
        RunManaAnimation(MaxMana, CurrentMana);
    }
    void RunHealtAnimation(float CurrentHealth, float MaxHealth)
    {
        AnimHealthSlider.maxValue = MaxHealth;
        if (LastHealth != 0)
        {
            if (CurrentHealth > 0)
            {
                AnimHealthSlider.value = LastHealth;
                LerpHealth = CurrentHealth;
                HealthLerp = true;
            }
            else
            {
                AnimHealthSlider.value = 0;
            }
        }
        else
        {
            LastHealth = CurrentHealth;
        }
    }

    void RunManaAnimation(int MaxMana, int CurrentMana)
    {
        AnimManaSlider.maxValue = MaxMana;

        if (LastMana != 0)
        {
            if (CurrentMana > 0)
            {
                AnimManaSlider.value = LastMana;
                LerpMana = CurrentMana;
                ManaLerp = true;
            }
            else
            {
                AnimManaSlider.value = 0;
            }
        }
        else
        {
            LastMana = CurrentMana;
        }
    }

    bool HealthLerp;
    float LerpHealth;

    bool ManaLerp;
    int LerpMana;
    private void Update()
    {
        if(HealthLerp)
        {
            AnimHealthSlider.value = Mathf.Lerp(AnimHealthSlider.value, LerpHealth -1, Time.deltaTime * 4f );
            if(AnimHealthSlider.value <= LerpHealth)
            {
                HealthLerp = false;
                LastHealth = LerpHealth;
            }
        }

        if(ManaLerp)
        {
            AnimManaSlider.value = Mathf.Lerp(AnimManaSlider.value, LerpMana -1, Time.deltaTime * 6f);
            if(AnimManaSlider.value <= LerpMana)
            {
                ManaLerp = false;
                LastMana = LerpMana;
            }
        }
    }

    public void SetElmenetOnFreame(List<Element> setEm)
    {
          if(setEm.Count > 0)
        {
            Freame.SetActive(true);
            foreach(Transform i in EmPickUPFreame)
            {
                Destroy(i.gameObject);
            }
            foreach(Element e in setEm)
            {
                Instantiate(e.ElementFreame, EmPickUPFreame.transform);
            }
        }
          else
        {
            Freame.SetActive(false);
            foreach (Transform i in EmPickUPFreame)
            {
                Destroy(i.gameObject);
            }
        }
    }
    public void KeyBinding(bool isOpen)
    {
        if(isOpen)
        {
            ClosePhase.SetActive(false);
            OpenPhase.SetActive(true);
        }
        else
        {
            ClosePhase.SetActive(true);
            OpenPhase.SetActive(false);
        }
    }

    public void SetBaseSkillImage(CurrentnSwap swaped)
    {
        if (swaped == CurrentnSwap.Player)
        {
            SkillImage.sprite = DashSprite; 
        }
        else
        {
            SkillImage.sprite = ShieldSprite;
        }
    }


    public void SetBaseSkillCooldown(float CurrentCooldown)
    {
        if(CurrentCooldown <= 0)
        {
            BaseWeaponCooldown.fillAmount = 0;
            coldowntext.text = "";
        }
        else
        {
            coldowntext.text = Mathf.Round(CurrentCooldown).ToString();
        }
    }
    public void SetElementSkillCooldown(float CurrentCoolDown)
    {
        if (CurrentCoolDown <= 0)
        {
         //   ElementnCooldown.fillAmount = 0;
         //   Elementcoldowntext.text = "";
        }
        else
        {
       //     Elementcoldowntext.text = Mathf.Round(CurrentCoolDown).ToString();
        }
    }
    public void SetElementSkillSprite(CurrentnSwap swaped, Element currnetElement)
    {
       if(swaped == CurrentnSwap.Player)
        {
        //    ElementSkillImage.sprite = currnetElement.MeleeSkillImg;
        }
        else
        {
         //   ElementSkillImage.sprite = currnetElement.MagicSkilImg;
        }
    }
}

