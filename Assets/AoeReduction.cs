using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeReduction : MonoBehaviour
{
    [SerializeField] float ExplotionRange;
    [SerializeField] ElementalBaseDamageStat BaseDamageStat;
    [SerializeField] float DamageMultiple;
    [SerializeField] ElementType type;
    [SerializeField] Element incomeEm;
    [SerializeField] float Delay;

    private void OnEnable()
    {
        Invoke("AoeRedcut", Delay);
    }

    public void AoeRedcut()
    {
        EnemyHealth[] enemy = GameObject.FindObjectsOfType<EnemyHealth>();
        foreach (EnemyHealth i in enemy)
        {
            if (Vector2.Distance(i.transform.position, this.transform.position) <= ExplotionRange)
            {
                float Damage = BaseDamageStat.GetBaseDamage(type).baseDamage * (DamageMultiple / 100);
                i.SetOxidation();
                i.TakeDamage(Damage, type);
                i.ReleaseReduction(incomeEm);
                i.GetComponent<Knockback>().PlayFeedBack(this.gameObject);
            }
        }
        this.enabled = false;
    }
}
