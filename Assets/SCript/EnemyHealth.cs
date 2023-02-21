using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
public class EnemyHealth : EnemyAttacking
{
    [SerializeField] float MaxHealth;
    [SerializeField] float CurrentHealth;
    [SerializeField] Transform PointSpawning;
    [SerializeField] float TextUpTime;
    [SerializeField] GameObject FloatingPoint;
    [SerializeField] Transform EffectPoiont;
    [SerializeField] StatHolder stat;
    
   public  delegate void Debuff();
    public Debuff DebuffHandle;

    private void Start()
    {
        MaxHealth = stat.CharacterBaseStat.MaxHp;
        CurrentHealth = MaxHealth;
    }
    public override void TakeDamage(float Damage)
    {

        if (AttackIncome != null && CurrentRedcution != null)
        {
            if(AttackIncome.TypeOfElement == CurrentRedcution.TypeOfElement)
            {
                CurrentHealth -= Damage * 0.5f * stat.BaseDebuffStat.DamageMultiple;
            }
        }
        else
        {
            CurrentHealth -= Damage * stat.BaseDebuffStat.DamageMultiple;
        }

        GameObject Point = Instantiate(FloatingPoint, PointSpawning.transform.position, Quaternion.identity) as GameObject;
        Point.transform.GetChild(0).GetComponent<TextMeshPro>().text = Damage.ToString();
        Destroy(Point, TextUpTime);
        
        if (CurrentHealth <=0 )
        {
            Destroy(gameObject);
        }
    }

    Element CurrentRedcution;
  Element  AttackIncome;
    public override void EmAttackType(Element type)
    {
        AttackIncome = type;
    }

    public override void SetReduction(Element ElementIncome)
    {
        CurrentRedcution = ElementIncome;
       foreach(Transform i in EffectPoiont)
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
            Instantiate(releaseted.ReactPrefab, this.transform.position, Quaternion.identity);
        }
    }




    ElmentReaction GetReaction(int sum)
    {
        return CurrentRedcution.possiblereact.FirstOrDefault(i => i.Value == sum);
    }

    public override void ONStatChange(bool changeToNormle)
    {
        if(changeToNormle)
        {

        }
        else
        {

        }
    }




}

