using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : Reaction
{
     StatusEffect effect;
    [SerializeField] float Time;
    public override void SetReaction(GameObject Target)
    {
        effect = Target.GetComponent<StatusEffect>();
        if(effect != null)
        {
            if(effect.isSlow())
            {
                Destroy(this.gameObject);
            }
            else
            {
                effect.OnSlow();
                Invoke("destroySelf", Time);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }



    void destroySelf()
    {
     
        if (effect != null)
        {
            effect.OffSlow();
        }

        Destroy(this.gameObject);
    }
  
}
