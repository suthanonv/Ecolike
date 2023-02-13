using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSlash : MonoBehaviour
{
    RotationToMouse rotate;
    [SerializeField] float DestoryTime;
    private void Start()
    {
        PlayerWalk.instance.StopWalk(true);
        rotate = GameObject.FindWithTag("Weapon").GetComponent<RotationToMouse>();
        rotate.enabled = false;
        MeleeAttack.instace.DisalbespirteAndLight(true);
        Destroy(this.gameObject, DestoryTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    private void OnDestroy()
    {
        MeleeAttack.instace.DisalbespirteAndLight(false);
        PlayerWalk.instance.StopWalk(false);
        rotate.enabled = true;

    }

}
