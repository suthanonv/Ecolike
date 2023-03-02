using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMeleeUtimate : MonoBehaviour
{
    [SerializeField] float Time;

    private void Start()
    {
        EffectManager.instance.OnBodyBuff(stateOnOff.on);
        Invoke("OffUtimate", Time);
    }


    void OffUtimate()
    {
        EffectManager.instance.OnBodyBuff(stateOnOff.off);
    }
}
