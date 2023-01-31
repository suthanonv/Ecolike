using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyHealth : DamageAble
{
    [SerializeField] float MaxHealth;
    [SerializeField] float CurrentHealth;
    [SerializeField] Transform PointSpawning;
    [SerializeField] float TextUpTime;
    public GameObject FloatingPoint;
    private void Start()
    {
        CurrentHealth = MaxHealth;
    }
    public override void TakeDamage(float Damage)
    {
        CurrentHealth -= Damage;
        GameObject Point = Instantiate(FloatingPoint, PointSpawning.transform.position, Quaternion.identity) as GameObject;
        Point.transform.GetChild(0).GetComponent<TextMeshPro>().text = Damage.ToString();
        Destroy(Point, TextUpTime);
        if (CurrentHealth <=0 )
        {
            Destroy(gameObject);
        }
    }
}
