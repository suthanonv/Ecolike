using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : DamageAble
{
    [SerializeField] float MaxHealth;
    float CurrentHealth;
    bool GotHit;
    [SerializeField] float EffectTime;
    float CurrentTime;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Color HitColor;
    private void Start()
    {
        CurrentHealth = MaxHealth;
        UiManager.instance.SetHealthValue(MaxHealth,CurrentHealth);
    }

    public override void TakeDamage(float Damage,ElementType type)
    {
        CurrentHealth -= Damage;
        GotHit = true;
        UiManager.instance.SetHealthValue(MaxHealth, CurrentHealth);
    }

    private void Update()
    {
        if(GotHit)
        {
            GotHit = false;
            RunHitAnimation.instance.RunHit(true);
            sprite.color = HitColor;
            CurrentTime = EffectTime;
        }
        if(CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
            if(CurrentTime <= 0)
            {
                RunHitAnimation.instance.RunHit(false);
                sprite.color = Color.white ;
            }
        }
    }



}
