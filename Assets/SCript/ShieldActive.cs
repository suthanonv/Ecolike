using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ShieldActive : MonoBehaviour
{
    Transform Point;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Light2D lights;
    [SerializeField] int Limit = 2;
    GameObject Player;

    private void Awake()
    {
        Player = GameObject.FindWithTag("Player");
    }
    private void Start()
    {
        Shield.instance.ActiveShield();
        Shield.instance.CanAciveShield(false);
        Point = GameObject.FindWithTag("Weapon").transform;
        this.transform.parent = Point;

        //PlayerWalk.instance.StopWalk(true);
        SetWeaponColor.instance.DisableBall(false);
    }
    private void Update()
    {
        this.transform.position = Point.transform.position;
    }

    private void OnDestroy()
    {
        Shield.instance.OffShiled();
        Shield.instance.CanAciveShield(true);
     //   PlayerWalk.instance.StopWalk(false);
        SetWeaponColor.instance.DisableBall(true);
    }

    public void SetColor(Element Current)
    {
        
        sprite.color = Current.ElementColor;
        lights.color = Current.ElementColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Knockback>().PlayFeedBack(Player);
            Limit--;
            if(Limit <=0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
