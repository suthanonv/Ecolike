using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerHealth : DamageAble
{
    public static PlayerHealth instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] float MaxHealth;
    float CurrentHealth;
    bool GotHit;
    [SerializeField] float EffectTime;
    float CurrentTime;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Color HitColor;
    public UnityEvent OnHit,Died;
    private void Start()
    {
        CurrentHealth = MaxHealth;
        UiManager.instance.SetHealthValue(MaxHealth,CurrentHealth);
    }

    public override void TakeDamage(float Damage,ElementType type)
    {
        OnHit.Invoke();
        CurrentHealth -= Damage;
        GotHit = true;
        UiManager.instance.SetHealthValue(MaxHealth, CurrentHealth);
        if(CurrentHealth <= 0)
        {
            Died.Invoke();
        }
    }

    public void Health(float HealthAMount)
    {
        CurrentHealth += HealthAMount;
        if(CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
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
