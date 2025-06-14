using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
public class SetWeaponColor : MonoBehaviour
{

    [SerializeField] Light2D lights;
    [SerializeField] RotationToMouse Mouse;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Image UtlmateBarColor;
    public static SetWeaponColor instance;



    private void Awake()
    {
        instance = this;

    }

    public void SetColor(int Value)
    {
        Element Show = ElementManage.instance.GetEm(Value);

        sprite.color = Show.ElementColor;
        lights.color = Show.ElementColor;
        UtlmateBarColor.color = Show.ElementColor;

    }

    public void DisableBall(bool isEnabled)
    {

        if (!isEnabled)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<Light2D>().enabled = false;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponent<Light2D>().enabled = true;
        }
    }

    public void OnStopRoate(bool stop)
    {
        if (stop)
        {
            Mouse.enabled = false;
        }
        else
        {
            Mouse.enabled = true;

        }
    }
}
