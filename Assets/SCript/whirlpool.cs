using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whirlpool : Reaction
{
    [SerializeField] float ActiveTime;
    [SerializeField] float ActiveRange;
    private void Start()
    {
        Destroy(this.gameObject, ActiveTime);
    }

    public override void SetReaction(GameObject Target)
    {
    }


    private void Update()
    {
        StatusEffect[] effect = GameObject.FindObjectsOfType<StatusEffect>();
           
        foreach(StatusEffect i in effect)
        {
            if(Vector2.Distance(this.transform.position,i.transform.position) <= ActiveRange)
            {
                i.OnSuck();
            }
        }
    }

    private void OnDestroy()
    {
        StatusEffect[] effect = GameObject.FindObjectsOfType<StatusEffect>();
        foreach (StatusEffect i in effect)
        {
            if (Vector2.Distance(this.transform.position, i.transform.position) <= ActiveRange)
            {
                i.OffSuck();
            }
        }
    }
}
