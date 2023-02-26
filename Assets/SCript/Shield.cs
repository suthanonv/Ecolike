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
    [SerializeField] SetKeyBinding key;

    private void Awake()
    {
        instance = this;
    }
    [SerializeField] UnityEvent OnShieldActive, OnShieldOff;


  [SerializeField]  float ShieldCD = 2;
    float CurrentCoolDown;
    float Animatedcooldown;
    private void Update()
    {
        if (CurrentCoolDown <= 0)
        {
            UiManager.instance.SetBaseSkillCooldown(CurrentCoolDown);
            if (Input.GetKey(key.WeapoNSkillKey) && CanShields)
            {
                
                GameObject CurrentaShield = Instantiate(Shields, Point.transform.position, RotatePoint.transform.rotation);
                CurrentaShield.GetComponent<ShieldActive>().SetColor(shooting.instance.CurrentEM);
                Destroy(CurrentaShield, ShieldUptime);
                CurrentCoolDown = ShieldCD;
                Animatedcooldown = ShieldCD;
                UiManager.instance.BaseWeaponCooldown.fillAmount = 1;
            }
        }
        else
        {

            CurrentCoolDown -= Time.deltaTime;
            UiManager.instance.BaseWeaponCooldown.fillAmount -= 1 / Animatedcooldown * Time.deltaTime;
            UiManager.instance.SetBaseSkillCooldown(CurrentCoolDown);
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

    private void OnEnable()
    {
        if(CurrentCoolDown > 0)
        {
            Animatedcooldown = CurrentCoolDown;
            UiManager.instance.BaseWeaponCooldown.fillAmount = CurrentCoolDown;
            UiManager.instance.SetBaseSkillCooldown(CurrentCoolDown);
        }
    }

}
