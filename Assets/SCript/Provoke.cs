using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Provoke : MonoBehaviour
{
    Transform Player;
    
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<EnemyWalk>()!= null)
        {
            collision.gameObject.GetComponent<EnemyWalk>().provoke(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyWalk>() != null)
        {
            collision.gameObject.GetComponent<EnemyWalk>().provoke(Player.transform);
        }
    }
}
