using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;
public enum CurrentnSwap
{
    Player,
    Weapon
}

public class SwapCamera : MonoBehaviour
{
    public static SwapCamera instance;

    [SerializeField] CinemachineVirtualCamera camLook;
    [SerializeField] Transform Player;
    [SerializeField] Transform Weapon;
    [SerializeField] KeyCode swapKey = KeyCode.Z;
    [SerializeField] UnityEvent SwapTP, SwapTW;
    public CurrentnSwap swap = CurrentnSwap.Player;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SwapToPlayer();
    }

    private void Update()
    {
        if(Input.GetKeyDown(swapKey) && swap == CurrentnSwap.Player)
        {
          
            SwapToWeapon();
        }
        else if(Input.GetKeyDown(swapKey) && swap == CurrentnSwap.Weapon)
        {
           
            SwapToPlayer();
        }
    }


    public void SwapToPlayer()
    {
        swap = CurrentnSwap.Player;
        camLook.Follow = Player;
        SwapTP.Invoke();
    }

    public void SwapToWeapon()
    {
        swap = CurrentnSwap.Weapon;
        camLook.Follow = Weapon;
        
        SwapTW.Invoke();
    }
}


