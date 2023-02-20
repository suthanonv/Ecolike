using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallKnockback : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag ("Wall"))
        {
            this.GetComponent<Knockback>().PlayFeedBack(collision.gameObject);
        }
    }


}
