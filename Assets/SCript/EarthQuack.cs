using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EarthQuack : MonoBehaviour
{
    [SerializeField] UnityEvent Damage;
    public void DestroSelf()
    {
        Destroy(this.gameObject);
    }

    public void StartDamage()
    {
        Damage.Invoke();
    }
}
