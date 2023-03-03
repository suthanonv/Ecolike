using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GolemHealth : DamageAble
{
    [SerializeField] float MaxHealth;
    float CurrentHealth;
    [SerializeField] Slider healthbar;
    private void Start()
    {
        CurrentHealth = MaxHealth;
        UpdateHealthbar();
    }
    public override void TakeDamage(float Damage, ElementType incomeType)
    {
        CurrentHealth -= Damage;
        UpdateHealthbar();
        if (CurrentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void UpdateHealthbar()
    {
        healthbar.maxValue = MaxHealth;
        healthbar.value = CurrentHealth;
    }
}
