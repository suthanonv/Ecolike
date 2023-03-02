using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : Reaction
{
     StatusEffect effect;
    [SerializeField] float Time;
    [SerializeField] GameObject self;
    public override void SetReaction(GameObject Target)
    {
        effect = Target.GetComponent<StatusEffect>();
        if(effect != null)
        {
            if(effect.isSlow())
            {
                Destroy(self);
            }
            else
            {
                effect.OnSlow();
                Invoke("Des", Time);
            }
        }
        else
        {
            Destroy(self);
        }
    }



    void Des()
    {
     
        if (effect != null)
        {
            effect.OffSlow();
        }

        Destroy(self);
    }
  
}
