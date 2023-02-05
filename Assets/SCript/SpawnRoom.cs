using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    public int Direction;
    public int WallDirection;
    [SerializeField] Transform Point;
    

    private void Start()
    {
        Invoke("SpawnRooms", 0.25f);
    }
    public void SetDirection(int newDirect)
    {
        Direction = newDirect;
    }

  public bool isSpawnDone = false;
    void SpawnRooms()
    {
        if (!isSpawnDone)
        {
            GameObject Rooms = Roomtemeplete.instance.GetRandomPoint(Direction);
           
            Instantiate(Rooms, Point.transform.position, Rooms.transform.rotation);
            isSpawnDone = true;
        }
        
    }
   


    public void SpawnWallPath()
    {
        if (!isSpawnDone)
        {
            isSpawnDone = true;
            GameObject Wall = Roomtemeplete.instance.GetWall(WallDirection);
            Instantiate(Wall, this.transform.position, Wall.transform.rotation);
            Destroy(this.gameObject);
        }
    }
    List<SpawnRoom> currentList;
    public void  RoomOverRoom(List<SpawnRoom> otherRoom)
    {
        isSpawnDone = true;
        List<SpawnRoom> currentList = otherRoom;
        Debug.Log(Check(currentList));
        if(Check(currentList))
        {
            
            GameObject Rooms = Roomtemeplete.instance.GetRoomByID(SetSum(currentList));
            
            Instantiate(Rooms, Point.transform.position, Rooms.transform.rotation);
        }
        
    }

    int SetSum(List<SpawnRoom> list)
    {
        int Sum = Direction * Direction;
        foreach (SpawnRoom i in list)
        {
            Sum += i.Direction * i.Direction;
        }
        return Sum;
    }

    bool Check(List<SpawnRoom> list)
    {
     
        foreach(SpawnRoom i in list)
        {
            if(i.Direction >= Direction)
            {
                return false;
            }
        }
        return true;
    }
  }


    
