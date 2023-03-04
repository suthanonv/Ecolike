using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSlash : MonoBehaviour
{
    RotationToMouse rotate;
    [SerializeField] float DestoryTime;
  
    float Damage;
    [SerializeField] Element SlashEm;
    [SerializeField] ElementType type;
    [SerializeField] ElementalBaseDamageStat stat;
    [SerializeField] float DmageMultiple = 100;
    [SerializeField] GameObject Parent;

    [Header("Alivible effect chance")]
    [SerializeField] List<EffectTypechance> chance = new List<EffectTypechance>();
    List<EffectChance> effect = new List<EffectChance>();

    private void Start()
    {
      
        foreach (EffectTypechance type in chance)
        {
            effect.Add(stat.GetEffect(type));
        }
    }
    private void OnEnable()
    {
        Damage = stat.GetBaseDamage(type).baseDamage * (DmageMultiple / 100);
        Parent.GetComponent<SpriteRenderer>().enabled = false;
        PlayerWalk.instance.StopWalk(true);
        rotate = GameObject.FindWithTag("Weapon").GetComponent<RotationToMouse>();
        rotate.enabled = false;
        StartCoroutine(SetActiveSelf(DestoryTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<EnemyAttacking>() != null)
        {
            other.GetComponent<EnemyAttacking>().TakeDamage(Damage, type);
        } 
        if (other.gameObject.GetComponent<Knockback>() != null && other.gameObject.tag != "Player")
        {
            other.GetComponent<Knockback>().PlayFeedBack(this.gameObject);
        }
        if(other.gameObject.GetComponent<StatusEffect>() != null)
        {
            RandEffect(other.gameObject);
        }
        if (other.gameObject.GetComponent<EnemyHealth>() != null)
        {
            other.GetComponent<EnemyHealth>().EmAttackType(SlashEm);
            other.GetComponent<EnemyHealth>().TakeDamage(Damage, type);
            other.GetComponent<EnemyHealth>().SetReduction(SlashEm);
        } 

       
    }

    void RandEffect(GameObject target)
    {
        float rand = Random.Range(0, 101);
        List<Reaction> possible = new List<Reaction>();
        foreach(EffectChance i in effect)
        {
            if(rand <= i.chance)
            {
                possible.Add(i.EffectPrefab);
            }
        }
        if(possible.Count > 0)
        {
        Reaction ef =    Instantiate(possible[Random.Range(0,possible.Count)], transform.position, Quaternion.identity);
            ef.SetReaction(target);
        }
            return;    
    }
    
    private void OnDisable()
    {
        Parent.GetComponent<SpriteRenderer>().enabled = true;
        PlayerWalk.instance.StopWalk(false);
        rotate.enabled = true;

    }

    IEnumerator SetActiveSelf(float Timeing)
    {
        yield return new WaitForSeconds(Timeing);
        Parent.GetComponent<SpriteRenderer>().enabled = true;
        this.enabled = false;
        this.gameObject.SetActive(false);
    }
}
