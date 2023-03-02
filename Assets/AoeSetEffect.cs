using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeSetEffect : MonoBehaviour
{
    [SerializeField] float ActiveRange;
    [SerializeField] float Delay;
    [SerializeField]  Reaction react;
    private void OnEnable()
    {
        Invoke("AoeStart", Delay);
    }

    public void AoeStart()
    {
        EnemyHealth[] enemy = GameObject.FindObjectsOfType<EnemyHealth>();
        foreach (EnemyHealth i in enemy)
        {
            if (Vector2.Distance(i.transform.position, this.transform.position) <= ActiveRange)
            {
                Reaction reat = Instantiate(react, this.transform.position, Quaternion.identity);
                react.SetReaction(i.gameObject);
            }
        }
        this.enabled = false;
    }
}
