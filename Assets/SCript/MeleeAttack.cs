using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MeleeAttack : MonoBehaviour
{
    public static MeleeAttack instace;
    [SerializeField] SpriteRenderer render;

    [SerializeField] Element WeaponElement;
    [SerializeField] Transform Point;
    [SerializeField] Light2D lights;
    Transform RotationPoint;
    [SerializeField] SetKeyBinding key;
    float ATKCD;
    float CurrentCD;
    private void Awake()
    {
        instace = this;
    }
    private void Start()
    {
        PlayerHealth.instance.OnHit.AddListener(CancelGate);
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
            if (Input.GetKey(key.AttackKey))
            {
          
                CurrentCharge = Mathf.Lerp(CurrentCharge, Limit + 1, Time.deltaTime);
                PlayerWalk.instance.OnSlow(true);
                MeleeChargeBar.instance.SetBar(Limit, CurrentCharge);
            }
            if (Input.GetKeyUp(key.AttackKey))
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

    public void CancelGate()
    {
        CurrentCharge = 0;
    }

    public void DisalbespirteAndLight(bool check)
    {
        if (check)
        {
            render.enabled = false;
            lights.enabled = false;
        }
        else
        {
            render.enabled = true;
            lights.enabled = true;

        }
    }
    private void OnDisable()
    {
        CurrentCharge = 0;
        MeleeChargeBar.instance.SetBar(Limit, 0);
    }

    private void OnDestroy()
    {
        PlayerHealth.instance.OnHit.RemoveListener(CancelGate);
    }

}