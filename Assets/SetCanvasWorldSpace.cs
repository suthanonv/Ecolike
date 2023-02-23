using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCanvasWorldSpace : MonoBehaviour
{
    private void Start()
    {
        this.GetComponent<Canvas>().worldCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }
}
