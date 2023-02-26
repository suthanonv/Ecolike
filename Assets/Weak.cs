using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weak : Reaction
{
    public StatusEffect effect;
    [SerializeField] float ActiveTime;
    public override void SetReaction(GameObject Target)
    {
        effect = Target.GetComponent<StatusEffect>();
        if (effect != null)
        {
            if (effect.isWeak())
            {
                Destroy(this.gameObject);
            }
            else
            {
                effect.OnWeak();
                Invoke("ResetWeak", ActiveTime);
            }
        }
    }



    void ResetWeak()
    {
        if(effect != null)
        {
            effect.OffWeak();
        }
        Destroy(this.gameObject);
    }
}
