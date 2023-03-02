using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SunImpact : MonoBehaviour
{
    [SerializeField] GameObject Phase1,Parent;

    [SerializeField] float Phase2StartTime;
    [SerializeField] UnityEvent OnStartPhase2;

    private void Start()
    {
        Phase1.SetActive(true);
        Invoke("Phaseing2", Phase2StartTime);
    }


    void Phaseing2()
    {
        Phase1.SetActive(false);
        OnStartPhase2.Invoke();
    }

    public void DestroyingSelf()
    {
        Destroy(Parent);
    }

}
