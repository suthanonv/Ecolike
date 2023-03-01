using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MagicWeaponState : MonoBehaviour
{
    [Header("Laser Beam")]
    [SerializeField] UnityEvent OnBeam, OffBeam;
}
