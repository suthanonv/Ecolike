using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    
    void RunManaAnimation()
    {

    }
    bool HealthLerp;
    float LerpHealth;

    bool ManaLerp;
    int LerpMana;
    private void Update()
    {
        if(HealthLerp)
        {
            AnimHealthSlider.value = Mathf.Lerp(AnimHealthSlider.value, LerpHealth -1, Time.deltaTime * 2.5f );
            if(AnimHealthSlider.value <= LerpHealth)
            {
                HealthLerp = false;
                LastHealth = LerpHealth;
            }
        }

        if(ManaLerp)
        {
            AnimManaSlider.value = Mathf.Lerp(AnimManaSlider.value, LerpMana -1, Time.deltaTime * 2.5f);
            if(AnimManaSlider.value <= LerpMana)
            {
                ManaLerp = false;
                LastMana = LerpMana;
            }
        }
    }
}

