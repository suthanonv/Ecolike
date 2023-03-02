using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeOxidation : MonoBehaviour
{
    [SerializeField] float ExplotionRange;
    [SerializeField] ElementalBaseDamageStat BaseDamageStat;
    [SerializeField] float DamageMultiple;
    [SerializeField] ElementType type;
    [SerializeField] Element incomeEm;
    [SerializeField] float Delay;

    private void OnEnable()
    {
        Invoke("AoeStart", Delay);
    }

    public  void AoeStart()
    {
        EnemyHealth[] enemy = GameObject.FindObjectsOfType<EnemyHealth>();
        foreach (EnemyHealth i in enemy)
        {
            if (Vector2.Distance(i.transform.position, this.transform.position) <= ExplotionRange)
            {
                float Damage = BaseDamageStat.GetBaseDamage(type).CurrentBaseDamage * (DamageMultiple / 100);
                i.EmAttackType(incomeEm);
                i.TakeDamage(Damage, type);
                i.SetReduction(incomeEm);
                i.GetComponent<Knockback>().PlayFeedBack(this.gameObject);
            }
        }
        this.enabled = false;
    }
}
