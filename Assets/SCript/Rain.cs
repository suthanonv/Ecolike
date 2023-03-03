using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Rain : MonoBehaviour
{
  
    
    [SerializeField] float ActiveTime;
    [SerializeField] ElementType type;
    [SerializeField] Element Em;
    [SerializeField] float DecreaseAmount;
    [SerializeField] float DamageIncrease;
    
    [SerializeField] ElementalBaseDamageStat stat;
   
    [Header("healing")]
    [SerializeField] float HealthMultiple;
    [SerializeField] float HealthElementStat;
    [SerializeField] float HealthCD;
    float CurrentCD;
    float CurrentPlus;
    bool inRange = false;
    bool isOnBuff;
    private void Start()
    {
        Destroy(this.gameObject, ActiveTime);
    }

    private void OnDestroy()
    {
        if (isOnBuff)
        {
            stat.GetBaseDamage(type).baseDamage -= CurrentPlus;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<StatHolder>() != null)
        {
            collision.gameObject.GetComponent<StatHolder>().GetResistanceBase(type).ResistantAmount -= (DecreaseAmount / 100);
        }
        if(collision.gameObject.tag == "Player")
        {
            inRange = true;
            CurrentPlus = stat.GetBaseDamage(type).baseDamage *(DamageIncrease / 100);
            stat.GetBaseDamage(type).baseDamage += CurrentPlus;
            isOnBuff = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
     if(collision.gameObject.GetComponent<EnemyHealth>() != null)
        {
            collision.gameObject.GetComponent<EnemyHealth>().ReleaseReduction(Em);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<StatHolder>() != null)
        {
            collision.gameObject.GetComponent<StatHolder>().GetResistanceBase(type).ResistantAmount += (DecreaseAmount / 100);
        }
        if(collision.gameObject.tag == "Player")
        {
            inRange = false;
            stat.GetBaseDamage(type).baseDamage -= CurrentPlus;
            isOnBuff = false;
        }
    }

    private void Update()
    {
        if(inRange)
        {
            if(CurrentCD <= 0)
            {
                float HealthAmount = HealthMultiple * (stat.GetBaseDamage(type).baseDamage * (HealthElementStat / 100));
                GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().Health(HealthAmount);
                CurrentCD = HealthCD;
            }
            else
            {
                CurrentCD -= Time.deltaTime;
            }
        }
    }

}
