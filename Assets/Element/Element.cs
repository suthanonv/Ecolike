using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Element : ScriptableObject
{
    public int Value;
    public GameObject ElementPrefab;
    public float Force;
    public bool isProjectile;
    public float BulletUpTime;
    public Color ElementColor;

}
