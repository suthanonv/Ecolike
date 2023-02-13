using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RanDuengeon : MonoBehaviour
{
    public static RanDuengeon instance;
    [SerializeField] float Spawning;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] List<GameObject> StartRoom = new List<GameObject>();
    Transform Player;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        GameObject SpawnRoom = StartRoom[Random.Range(0, StartRoom.Count)];
        SetRoom();
    }

    public void newDuengeonGenerat()
    {
        PlayerWalk.instance.OnWarping(true);
        Invoke("StartRandRoom",0.5f);
    }
    
    void StartRandRoom()
    {
        Roomtemeplete.instance.RandNewDuengeon();
        GameObject[] PathParent = GameObject.FindGameObjectsWithTag("PathParent");
        foreach (GameObject i in PathParent)
        {
            Destroy(i);
        }
        Invoke("SetRoom", 0.25f);
    }
        

    public void SetRoom()
    {
        GameObject SpawnRoom = StartRoom[Random.Range(0, StartRoom.Count)];
        Instantiate(SpawnRoom, Player.transform.position, SpawnRoom.transform.rotation);
    }

}
