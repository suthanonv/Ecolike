using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stune : Reaction
{
    StatusEffect effect;
    [SerializeField] float Time;
    public override void SetReaction(GameObject Target)
    {
        effect = Target.GetComponent<StatusEffect>();
        if (effect != null)
        {
            if (effect.isStun())
            {
                Destroy(this.gameObject);
            }
            else
            {
                effect.OnStun();
                Invoke("Dtest", Time);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }



    void Dtest()
    {

        if (effect != null)
        {
            effect.OffStun();
        }

        Destroy(this.gameObject);
    }
}
