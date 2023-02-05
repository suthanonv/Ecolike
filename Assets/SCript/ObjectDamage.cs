using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectDamage : DamageAble
{
    [SerializeField] float Health;
    float CurrentHealth;
    [SerializeField] Animator anim;
    [SerializeField] float TextUpTime;
    [SerializeField] Transform PointSpawning;
    public GameObject FloatingPoint;
    private void Start()
    {
        CurrentHealth = Health;
    }
    public override void TakeDamage(float Damage)
    {
        CurrentHealth -= Damage;
        GameObject Point = Instantiate(FloatingPoint, PointSpawning.transform.position, Quaternion.identity) as GameObject;
        Point.transform.GetChild(0).GetComponent<TextMeshPro>().text = Damage.ToString();
        Destroy(Point, TextUpTime);
        if (CurrentHealth <= 0)
        {
            anim.SetBool("isDestroy", true);
        }
    }
}
