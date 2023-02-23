 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationToMouse : MonoBehaviour
{
    private Camera MainCam;
    private Vector3 mousePos;

    void Start()
    {
        MainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        if (!pause)
        {
            mousePos = MainCam.ScreenToWorldPoint(Input.mousePosition);

            Vector3 rotation = mousePos - transform.position;

            float rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotz);
        }
    }

    bool pause;
    public void Pauseed(bool isPaused)
    {
        pause = isPaused;
    }
}
