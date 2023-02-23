using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectDamage : EnemyAttacking
{
    [SerializeField] float Health;
    float CurrentHealth;
    [SerializeField] Animator anim;
    [SerializeField] float TextUpTime;
    [SerializeField] Transform PointSpawning;
    [SerializeField] GameObject FloatingPoint;
    [SerializeField] ObjecType thisObjectType;
    enum ObjecType
    {
        Box,
        Jar
        }
    private void Start()
    {
        CurrentHealth = Health;
    }
    public override void TakeDamage(float Damage,ElementType type)
    {
        CurrentHealth -= Damage;
        GameObject Point = Instantiate(FloatingPoint, PointSpawning.transform.position, Quaternion.identity) as GameObject;
        Point.transform.GetChild(0).GetComponent<TextMeshPro>().text = Damage.ToString();
        Destroy(Point, TextUpTime);
        if (CurrentHealth <= 0)
        {
            anim.SetBool("isDestroy", true);
            if(thisObjectType == ObjecType.Box)
            {
                SoundManageMent.instance.PlayBlockBroken();
            }
           else if (thisObjectType == ObjecType.Jar)
            {
                SoundManageMent.instance.PLayJarBroken();
            }
        }
    }
}
