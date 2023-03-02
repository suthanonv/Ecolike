using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class dragonSlash : MonoBehaviour
{
    [SerializeField] UnityEvent Damage;
    Transform player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    private void Update()
    {
        this.transform.position = player.transform.position;
    }
    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }

    public void CanDamage()
    {
        Damage.Invoke();
    }
}
