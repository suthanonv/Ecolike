using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.Events;
public class EnemyHealth : EnemyAttacking
{
    
     float MaxHealth;
     float CurrentHealth;
  
    [Header("Damage Text")]
    [SerializeField] Transform PointSpawning;
    [SerializeField] float TextUpTime;
    [SerializeField] GameObject FloatingPoint;
    [SerializeField] float maxX, maxY, minX, minY;

    [Header("Reaction Ui")]
    [SerializeField] GameObject EffectParent;
    [SerializeField] Transform EffectPoiont;
     
    [Header("Stat")]
    [SerializeField] StatHolder stat;

    [Header("OnDied")]
    [SerializeField] UnityEvent OnDied;
    
   public  delegate void Debuff();
    public Debuff DebuffHandle;

    float RandX()
    {
        float randed = Random.Range(minX, minY);
        return randed;
    }

    float RandY()
    {
        float randed = Random.Range(minY, maxY);
        return randed;
    }

    private void Start()
    {
        MaxHealth = stat.CharacterBaseStat.MaxHp;
        CurrentHealth = MaxHealth;
    }

    public override void TakeDamage(float Damage, ElementType incomeType)
    {
        Damage *= stat.GetResistance(incomeType);
        float DamageShowing = Damage;

        if (!isINcomeOxid)
        {
            if (AttackIncome != null && CurrentRedcution != null)
            {
                if (AttackIncome.TypeOfElement == CurrentRedcution.TypeOfElement)
                {
                    CurrentHealth -= Damage * 0.5f * stat.BaseDebuffStat.DamageMultiple;
                    DamageShowing = Damage * 0.5f * stat.BaseDebuffStat.DamageMultiple;
                }
            }
            else
            {
                CurrentHealth -= Damage * stat.BaseDebuffStat.DamageMultiple;
                DamageShowing = Damage * stat.BaseDebuffStat.DamageMultiple;
            }
        }
        else
        {
            if(CurrentRedcution == null)
            {
                CurrentHealth -= Damage * 0.5f * stat.BaseDebuffStat.DamageMultiple;
                DamageShowing = Damage * 0.5f * stat.BaseDebuffStat.DamageMultiple;
            }
            else
            {
                CurrentHealth -= Damage * stat.BaseDebuffStat.DamageMultiple * 2;
                DamageShowing = Damage * stat.BaseDebuffStat.DamageMultiple * 2;
            }
            isINcomeOxid = false;
        }
        int showed = Mathf.RoundToInt(DamageShowing);

        GameObject Point = Instantiate(FloatingPoint,new Vector2(PointSpawning.transform.position.x + RandX(), PointSpawning.transform.position.y + RandY()), Quaternion.identity) as GameObject;
        Point.transform.GetChild(0).GetComponent<TextMeshPro>().text = showed.ToString();
        Destroy(Point, TextUpTime);

        if (CurrentHealth <= 0)
        {
            OnDied.Invoke();
            Destroy(gameObject);
        }
    }


    Element CurrentRedcution;
  Element  AttackIncome;
    public override void EmAttackType(Element type)
    {
        AttackIncome = type;
    }

    bool isINcomeOxid;
    public void SetOxidation()
    {
        isINcomeOxid = true;
    }

    public override void SetReduction(Element ElementIncome)
    {
        CurrentRedcution = ElementIncome;
        EffectParent.SetActive(true);
       foreach (Transform i in EffectPoiont)
        {
            Destroy(i.gameObject);
        }
       Instantiate(CurrentRedcution.ReactionFream, EffectPoiont.transform);
    }

    public override void ReleaseReduction(Element ElemnetIncome)
    {
        if(CurrentRedcution != null)
        {
            int Sum = CurrentRedcution.Value - ElemnetIncome.Value;
            ElmentReaction releaseted = GetReaction(Sum);
        Reaction react = Instantiate(releaseted.ReactPrefab, this.transform.position, Quaternion.identity).GetComponent<Reaction>();
            react.SetReaction(this.gameObject);
            EffectParent.SetActive(false);
            CurrentRedcution = null;
        }
    }




    ElmentReaction GetReaction(int sum)
    {
        return CurrentRedcution.possiblereact.FirstOrDefault(i => i.Value == sum);
    }

   

    

}

