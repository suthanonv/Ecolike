using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MeleeAttack : MonoBehaviour
{
    public static MeleeAttack instace;
    [SerializeField] GameObject Slash;
    [SerializeField] SpriteRenderer render;

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
    float Limit;
    float CurrentCharge = 0;
    private void Update()
    {
        if (CurrentCD <= 0)
        {
            Limit = WeaponElement.MeleeUltiChargeTime;
            MeleeChargeBar.instance.SetColor(WeaponElement);
            if (Input.GetKey(AttackKey))
            {
                CurrentCharge = Mathf.Lerp(CurrentCharge, Limit + 1, Time.deltaTime);
                PlayerWalk.instance.OnSlow(true);
                MeleeChargeBar.instance.SetBar(Limit, CurrentCharge);
            }
            if (Input.GetKeyUp(AttackKey))
            {
                if (CurrentCharge < Limit)
                {

                    Instantiate(WeaponElement.MeleePrefab, Point.transform.position, RotationPoint.transform.rotation);

                }
                else
                {

                }
                CurrentCD = ATKCD;
                CurrentCharge = 0;
                PlayerWalk.instance.OnSlow(false);
                MeleeChargeBar.instance.SetBar(Limit, 0);
            }

        }
        else
        {
            CurrentCD -= Time.deltaTime;
        }

    }

    public void DisalbespirteAndLight(bool check)
    {
        if (check)
        {
            render.enabled = false;

        }
        else
        {
            render.enabled = true;

        }



    }
    private void OnDisable()
    {
        CurrentCharge = 0;
        MeleeChargeBar.instance.SetBar(Limit, 0);

    }

}