using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMeleeUtimate : MonoBehaviour
{
    [SerializeField] float Time;
    public static MagicMeleeUtimate insatnce;
    private void Awake()
    {
        if(insatnce == null)
        {
            insatnce = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        EffectManager.instance.OnBodyBuff(stateOnOff.on);
        Invoke("OffUtimate", Time);
    }


    void OffUtimate()
    {
        EffectManager.instance.OnBodyBuff(stateOnOff.off);
        Destroy(this.gameObject);
    }
}
