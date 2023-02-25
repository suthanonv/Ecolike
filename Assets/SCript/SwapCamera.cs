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
    [SerializeField] KeyCode swapKey = KeyCode.Z;
    [SerializeField] UnityEvent SwapTP, SwapTW;
    public CurrentnSwap swap = CurrentnSwap.Player;
    [SerializeField] float SwapingCooldown;
    float CurrentCoolDown;
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
        if (CurrentCoolDown <= 0)
        {
            if (Input.GetKeyDown(swapKey) && swap == CurrentnSwap.Player)
            {
                SwapToWeapon();
                CurrentCoolDown = SwapingCooldown;
            }
            else if (Input.GetKeyDown(swapKey) && swap == CurrentnSwap.Weapon)
            {

                SwapToPlayer();
                CurrentCoolDown = SwapingCooldown;
            }
        }
        else
        {
            CurrentCoolDown -= Time.deltaTime;
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
        
        SwapTW.Invoke();
    }
}


