using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RanDuengeon : MonoBehaviour
{
    [SerializeField] List<GameObject> StartRoom = new List<GameObject>();
    Transform Player;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        GameObject SpawnRoom = StartRoom[Random.Range(0, StartRoom.Count)];
        Instantiate(SpawnRoom, Player.transform.position, SpawnRoom.transform.rotation);
    }

   
}
