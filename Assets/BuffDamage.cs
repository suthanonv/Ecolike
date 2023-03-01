using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffDamage : MonoBehaviour
{
    [SerializeField] ElementalBaseDamageStat stat;
    [SerializeField] float DamageMultiple;
    [SerializeField] float Time;
    [SerializeField] ElementType type;
    [SerializeField] float Delay;
    [SerializeField] float BuffUpTime;


    public static BuffDamage instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    float currentBuff;
    void Start()
    {
        Invoke("Buff",0);
    }
    
    public void Buff()
    {
        currentBuff = ((stat.GetBaseDamage(type).baseDamage * DamageMultiple)/ 100);
        stat.GetBaseDamage(type).baseDamage += currentBuff;
    }


    IEnumerator dropBuffDown()
    {
        yield return new WaitForSeconds(BuffUpTime);
        stat.GetBaseDamage(type).baseDamage -= currentBuff;
        Destroy(this.gameObject);
    }
}
