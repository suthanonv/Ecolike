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

    public void ReleaseEM(Element inUSe)
    {
        Element em = inUSe;
        SoundManageMent.instance.PlayCustomSound(em.CastingSound);
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

    public void ReleaseUtimate(Element CurrentEM)
    {
        if(CurrentEM.UtimateProjectile.isProjectile)
        {
            GameObject elm = Instantiate(CurrentEM.MagicUtimatePrefab, Point.transform.position, RotatePoint.transform.rotation);
            Rigidbody2D rb = elm.GetComponent<Rigidbody2D>();
            rb.AddForce(Point.up * CurrentEM.UtimateProjectile.Force, ForceMode2D.Impulse);
        }
        else
        {
            Instantiate(CurrentEM.MagicUtimatePrefab, Point.transform.position,Quaternion.identity);
        }
    } 


 public   Element GetEm(int value)
    {
        return EmList.AllEm.FirstOrDefault(i => i.Value == value);
    }

    public Element GetEmByRequire(List<Element> CurrentList)
    {
        if (CurrentList.Count > 0)
        {
            foreach (Element i in EmList.AllEm)
            {
                foreach (RequireElment w in i.AllRequire)
                {
                 if(w.RequiredEM.Count == CurrentList.Count)
                    {
                        int check = 0;
                        for(int count =0; count < CurrentList.Count;)
                        {
                            if(w.RequiredEM[count] != CurrentList[count])
                            {
                                check++;
                            }
                            count++;
                        }
                        if(check <= 0)
                        {
                            return i;
                        }
                    }
                }
            }
        }
     
        
        return EmList.AllEm.FirstOrDefault(i => i.Value == 0);
    }
  
}
