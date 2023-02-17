using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MeleeChargeBar : MonoBehaviour
{
    public static MeleeChargeBar instance;
    [SerializeField] Slider ChrageBar;
    [SerializeField] Image BarColor;
    [SerializeField] GameObject SldierBar;
    private void Awake()
    {
        instance = this;
    }
   
    public void SetBar(float maxGage,float Current)
    {
        ChrageBar.maxValue = maxGage;
        if (Current > 0)
        {
            SldierBar.SetActive(true);
        }
        else
        {
            SldierBar.SetActive(false);
        }
        if(Current > maxGage)
        {
            Current = maxGage;
        }
        
        ChrageBar.value = Current;
    }

    public void SetColor(Element currentElment)
    {
        BarColor.color = currentElment.ElementColor;
    }
    }

