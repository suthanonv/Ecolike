using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationLightController : MonoBehaviour
{
    [SerializeField] List<GameObject> LightControll = new List<GameObject>();
    int currentCount = 0;
    int maxCount;
    
    public void NextLight()
    {
           if(currentCount > 0)
        {
            LightControll[currentCount-1].SetActive(false);

        }
        if (currentCount < LightControll.Count)
        {
            LightControll[currentCount].SetActive(true);
            currentCount++;
        }
      
    }

    public void OffAllLight()
    {
        foreach(GameObject i in LightControll)
        {
            i.SetActive(false);
        }
        currentCount = 0;
    }

    public void DisableLight()
    {
        LightControll[currentCount].SetActive(false);
    }

}
