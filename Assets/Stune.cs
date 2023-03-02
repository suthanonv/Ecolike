using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stune : Reaction
{
    StatusEffect effect;
    [SerializeField] float Time;
    [SerializeField] GameObject self;
    public override void SetReaction(GameObject Target)
    {
        effect = Target.GetComponent<StatusEffect>();
        if (effect != null)
        {
            if (effect.isStun())
            {
                Destroy(self);
            }
            else
            {
                effect.OnStun();
                Invoke("Dtest", Time);
            }
        }
        else
        {
            Destroy(self);
        }
    }



    void Dtest()
    {

        if (effect != null)
        {
            effect.OffStun();
        }

        Destroy(self);
    }
}
