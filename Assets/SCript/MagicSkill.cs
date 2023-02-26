using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MagicSkill : MonoBehaviour
{
    public static MagicSkill instance;
    Element CurrentElement;
    [SerializeField] Transform Point;
    [SerializeField] Transform rotatePoint;
    [SerializeField] KeyCode skillKey;
    public UnityEvent OnSkillActive;
    float Animation;

    private void Awake()
    {
        instance = this;
    }

    public void SetElement(Element newElement)
    {
        CurrentElement = newElement;
        if(CurrentElement.CurrentMagicSkillCooldown > 0)
        {
            Animation = CurrentElement.CurrentMagicSkillCooldown;
            UiManager.instance.ElementnCooldown.fillAmount = Animation;
        }
    }

    private void Update()
    {
        if (CurrentElement.CurrentMagicSkillCooldown <= 0)
        {
            if (Input.GetKeyDown(skillKey))
            {
                if (canCast())
                {
                    CastingSkill();
                    CurrentElement.CurrentMagicSkillCooldown = CurrentElement.MagicSkillCooldown;
                    Animation = CurrentElement.CurrentMagicSkillCooldown;
                    UiManager.instance.ElementnCooldown.fillAmount = 1;
                }
            }
        }
        else
        {
            UiManager.instance.ElementnCooldown.fillAmount -= 1 / Animation * Time.deltaTime;
            CurrentElement.CurrentMagicSkillCooldown -= Time.deltaTime;
            UiManager.instance.SetElementSkillCooldown(CurrentElement.CurrentMagicSkillCooldown);
        }
    }

    bool canCast()
    {
        if (PlayerMana.instance.CurrentMana >= CurrentElement.MagicSkillManaCost)
        {
            PlayerMana.instance.CurrentMana -= CurrentElement.MagicSkillManaCost;
            return true;
        }
        return false;
    }

    void CastingSkill()
    {
        if (CurrentElement.MgProjectileCheck.isProjectile)
        {
            GameObject projectile = Instantiate(CurrentElement.MagicSkillPrefab, Point.transform.position, rotatePoint.transform.rotation);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.AddForce(Point.up * CurrentElement.MgProjectileCheck.Force, ForceMode2D.Impulse);
        }
        else
        {
            Instantiate(CurrentElement.MagicSkillPrefab, Point.transform.position, Quaternion.identity);
        }
    }
}
