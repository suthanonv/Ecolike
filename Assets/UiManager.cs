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
    [SerializeField] Slider HealtSlider;
    [SerializeField] Slider AnimHealthSlider;
    [SerializeField] Slider ManaSlider;

    int LastMana;
    float LastHealth;
 
   
        public void SetHealthValue(float MaxHealh, float CurrentHealth)
    {
        HealtSlider.maxValue = MaxHealh;
        HealtSlider.value = CurrentHealth;
        RunHealtAnimation(CurrentHealth, MaxHealh);
    }

    public void SetManaValue(float MaxMana, float CurrentMana)
    {
        ManaSlider.value = CurrentMana;
        ManaSlider.maxValue = MaxMana;
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
    void RunManaAnimation()
    {

    }
    bool HealthLerp;
    float LerpHealth;
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
    }
}

