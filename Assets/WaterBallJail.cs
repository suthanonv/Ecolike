using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBallJail : Reaction
{
    StatusEffect effect;
    [SerializeField] float FreezeTime;

    public override void SetReaction(GameObject Target)
    {
        effect = Target.GetComponent<StatusEffect>();
        if (effect != null)
        {
            if (!effect.isFreeze())
            {
                effect.OnFreeze();
                StartCoroutine(Unfreeze());
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
        
       
    }

    IEnumerator  Unfreeze()
    {
        yield return new WaitForSeconds(FreezeTime);
        if (effect != null)
        {
            effect.OffFreeze();
        }
        Destroy(this.gameObject);
    }




}
