using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Shield : MonoBehaviour
{
    public static Shield instance;
    public GameObject Shields;
    [SerializeField] Transform Point;
    [SerializeField] float ShieldUptime = 2;
    [SerializeField] Transform RotatePoint;

    private void Awake()
    {
        instance = this;
    }
    [SerializeField] UnityEvent OnShieldActive, OnShieldOff;

    public KeyCode ShieldKey = KeyCode.F;
  [SerializeField]  float ShieldCD = 2;
    float CurrentCoolDown;
    private void Update()
    {
        if (CurrentCoolDown <= 0)
        {
            if (Input.GetKey(ShieldKey) && CanShields)
            {
                
                GameObject CurrentaShield = Instantiate(Shields, Point.transform.position, RotatePoint.transform.rotation);
                CurrentaShield.GetComponent<ShieldActive>().SetColor(shooting.instance.CurrentEM);
                Destroy(CurrentaShield, ShieldUptime);
                CurrentCoolDown = ShieldCD;
            }
        }
        else
        {
            CurrentCoolDown -= Time.deltaTime;
        }
    }
    bool CanShields = true;
    public void CanAciveShield(bool CanShield)
    {
        if(!CanShield)
        {
            CanShield = false;
        }
        else
        {
            CanShield = true;
        }

    }

    public void ActiveShield()
    {
        OnShieldActive.Invoke();
    }

    public void OffShiled()
    {
        OnShieldOff.Invoke();
    }

 
}
