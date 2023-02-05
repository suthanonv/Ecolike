using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public SpawnRoom Parent;
    List<SpawnRoom> OverRoom = new List<SpawnRoom>();
    int count = 0;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Room")
        {
            if (count == 0)
            {
                Parent.SpawnWallPath();
            }
        }
        
        if(collision.gameObject.tag == "SpawnPoint")
        {
            if (collision.gameObject.GetComponent<CheckPoint>().Parent.isSpawnDone == false && Parent.isSpawnDone == false)
            {

                if (Check(collision.gameObject.GetComponent<CheckPoint>().Parent))
                {
                    OverRoom.Add(collision.gameObject.GetComponent<CheckPoint>().Parent);
                    Debug.Log(OverRoom.Count);
                    Invoke("SendOnOver", 0.1f);
                }
            }
        }
    }
    void SendOnOver()
    {

        Parent.GetComponent<SpawnRoom>().RoomOverRoom(OverRoom);
    }


    bool Check(SpawnRoom currnetSpawnRoom)
    {
        foreach(SpawnRoom i in OverRoom)
        {
            if(currnetSpawnRoom.Direction == i.Direction)
            {
                return false;
            }
        }
        return true;
    }


    
}
