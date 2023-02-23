using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Knockback : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2d;
    [SerializeField]
    private float strength = 16, delay = 0.15f;

    public UnityEvent OnBegin, Ondone;

    GameObject Player;
    [SerializeField] bool isEnemy;
    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    public void PlayFeedBack(GameObject sender)
    {
        float CurrentStength = strength;
        float CurrentDelay = delay;

        StopAllCoroutines();
        OnBegin?.Invoke();
         if(isEnemy)
        {
            sender = Player;
        }
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        rb2d.AddForce(direction * CurrentStength, ForceMode2D.Impulse);
        StartCoroutine(Reset(CurrentDelay));
    }

    public void NormleFeedBack(GameObject sender)
    {
        float CurrentStength = strength /2;
        float CurrentDelay = delay;
        StopAllCoroutines();
        OnBegin?.Invoke();
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        rb2d.AddForce(direction * CurrentStength, ForceMode2D.Impulse);
        StartCoroutine(Reset(CurrentDelay));
    }

    private IEnumerator Reset(float delays)
    {
        yield return new WaitForSeconds(delays);
        rb2d.velocity = Vector3.zero;
        Ondone?.Invoke();
    }
}
