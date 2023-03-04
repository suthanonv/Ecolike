using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    [SerializeField] KeyCode key = KeyCode.Escape;
    bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(key) && isPaused == false)
        {
            isPaused = true;
            globalPause.instance.globalPaused.Invoke(isPaused);
        }
        if(Input.GetKeyDown(key) && isPaused == true)
        {
            isPaused = false;
            globalPause.instance.globalPaused.Invoke(isPaused);
        }

    }

}
