using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RunHitAnimation : MonoBehaviour
{
    [SerializeField] Color HitColor;
    [SerializeField] Image sprite;
    public static RunHitAnimation instance;

    private void Awake()
    {
        instance = this;
    }
    public void RunHit(bool Hit)
    {
        if(Hit)
        {
            sprite.color = HitColor;
        }
        else
        {
            sprite.color = Color.white;
        }
    }
}
