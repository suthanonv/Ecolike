using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ElementManage : MonoBehaviour
{
    public static ElementManage instance;
    [SerializeField] Transform Point;
    [SerializeField] Transform RotatePoint;
    [SerializeField] ElementList EmList;
    private void Awake()
    {
        instance = this;
    }

    public void ReleaseEM(int value)
    {
        Element em = GetEm(value);

        if(em.isProjectile)
        {
            GameObject element = Instantiate(em.ElementPrefab, Point.transform.position, RotatePoint.transform.rotation);
            Rigidbody2D rb = element.GetComponent<Rigidbody2D>();
            rb.AddForce(Point.up * em.Force, ForceMode2D.Impulse);
            Destroy(element, em.BulletUpTime);
        }
        else
        {
            Instantiate(em.ElementPrefab, Point.transform.position, Quaternion.identity);
        }
    }


 public   Element GetEm(int value)
    {
        return EmList.AllEm.FirstOrDefault(i => i.Value == value);
    }
}
