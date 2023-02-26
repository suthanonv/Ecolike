using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SwordSkill : MonoBehaviour
{
    [SerializeField] Transform Point;
    [SerializeField] Element SkillElemet;
    [SerializeField] KeyCode skilkey = KeyCode.G;
    float Animation;
    Transform rotatePoint;
    public UnityEvent OnSkillActive;

    private void Start()
    {
        if(SkillElemet.CurrentMeleeSkillCooldown > 0)
        {
            Animation = SkillElemet.CurrentMeleeSkillCooldown;
        }
    }

    public void SetRotationPoint(Transform point)
    {
        rotatePoint = Point;
    }

    private void Update()
    {
        if(SkillElemet.CurrentMeleeSkillCooldown <= 0)
        {
            if(Input.GetKeyDown(skilkey))
            {
                if (canCast())
                {
                    CastingSkill();
                    SkillElemet.CurrentMeleeSkillCooldown = SkillElemet.MeleeSkillCooldown;
                    Animation = SkillElemet.MeleeSkillCooldown;
                    UiManager.instance.ElementnCooldown.fillAmount = 1;
                }
            }
        }
        else
        {
            UiManager.instance.ElementnCooldown.fillAmount -= 1 / Animation * Time.deltaTime;
            SkillElemet.CurrentMeleeSkillCooldown -= Time.deltaTime;
            UiManager.instance.SetElementSkillCooldown(SkillElemet.CurrentMeleeSkillCooldown);
        }
    }

    bool canCast()
    {
        if(PlayerMana.instance.CurrentMana >= SkillElemet.MeleeSkillManaCost)
        {
            PlayerMana.instance.CurrentMana -= SkillElemet.MeleeSkillManaCost;
            return true;
        }
        return false;
    }

    void CastingSkill()
    {
        if(SkillElemet.MeProjectileCheck.isProjectile)
        {
            GameObject projectile = Instantiate(SkillElemet.MeleeSkillPrefab, Point.transform.position, rotatePoint.transform.rotation);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.AddForce(Point.up * SkillElemet.MeProjectileCheck.Force, ForceMode2D.Impulse);
        }
        else
        {
            Instantiate(SkillElemet.MeleeSkillPrefab, Point.transform.position, Quaternion.identity);
        }
    }
}
