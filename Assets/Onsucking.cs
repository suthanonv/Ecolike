using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onsucking : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float SuckForce;
    Transform sukcPoint;
    Vector2 suck;
    public void SetTransform(Transform suckpoint)
    {
        this.sukcPoint = suckpoint;
    }


    private void Update()
    {
        Vector3 direction = sukcPoint.position - transform.position;

        direction.Normalize();
        suck = direction;
    }

    private void FixedUpdate()
    {
       rb.MovePosition((Vector2)transform.position + (suck * Time.deltaTime * SuckForce));
    }

}
