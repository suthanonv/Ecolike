using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public SpawnRoom Parent;
    List<SpawnRoom> OverRoom = new List<SpawnRoom>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Room")
        {
            Parent.SpawnWallPath();
        }
        
        if(collision.gameObject.tag == "SpawnPoint")
        {
            if(collision.gameObject.GetComponent<CheckPoint>().Parent.isSpawnDone == false && Parent.isSpawnDone == false)
            {
                OverRoom.Add(collision.gameObject.GetComponent<CheckPoint>().Parent);
                Invoke("SendOnOver", 0.1f);
            }
        }
    }
    void SendOnOver()
    {
        Parent.GetComponent<SpawnRoom>().RoomOverRoom(OverRoom);
    }
}
