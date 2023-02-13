using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MeleeAttack : MonoBehaviour
{
    public static MeleeAttack instace;
    [SerializeField] GameObject Slash;
    [SerializeField] SpriteRenderer render;
    [SerializeField] Light2D lightes;
    [SerializeField] Element WeaponElement;
    [SerializeField] Transform Point;
    Transform RotationPoint;
    public KeyCode AttackKey = KeyCode.Mouse0;
    float ATKCD;
    float CurrentCD;
    private void Awake()
    {
        instace = this;
    }
    private void Start()
    {
        RotationPoint = GameObject.FindWithTag("Weapon").transform;
        ATKCD = WeaponElement.MeleeAttackCD;
    }

    private void Update()
    {
        if(CurrentCD <= 0)
        {
            if(Input.GetKeyDown(AttackKey))
            {
                Instantiate(WeaponElement.MeleePrefab, Point.transform.position, RotationPoint.transform.rotation);
                CurrentCD = ATKCD;
            }
        }
        else
        {
            CurrentCD -= Time.deltaTime;
        }
                
    }

    public void DisalbespirteAndLight(bool check)
    {
        if(check)
        {
            render.enabled = false;
            lightes.enabled = false;
        }
        else
        {
            render.enabled = true;
            lightes.enabled = true;
        }
    }


}
