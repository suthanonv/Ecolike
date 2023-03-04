using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpMagnet : MonoBehaviour
{
    [SerializeField] Transform MagnetToPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<ExpCoin>() != null)
        {
            collision.gameObject.GetComponent<ExpCoin>().SetPointTo(MagnetToPoint);
        }
    }
}
