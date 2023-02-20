using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCollider : MonoBehaviour
{
    [SerializeField] Direct currnetDirect;
    [SerializeField] Transform Point;
    enum Direct
    {
        UP,Down
    }

    private void Update()
    {
        this.transform.position = Point.transform.position;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "obstacle")
            {
            if(currnetDirect == Direct.Down)
            {
                ChangeSpriteOrder.instacne.ChangeDownPoint();
            }
            else
            {

                ChangeSpriteOrder.instacne.ChangeUpPoint();
            }
        }
    }
}
