using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Roomtemeplete : MonoBehaviour
{
    public static Roomtemeplete instance;
    [SerializeField] int RoomMax;
    [SerializeField] public List<GameObject> RoomList;
    [SerializeField] PointList Allpoint;
    [SerializeField] List<AllPoint> allALivablePoint = new List<AllPoint>();
    public SpawnRoom[] PahtList;
    public GameObject[] Wall;
    [SerializeField] GameObject ExitDoor;

    [SerializeField] int RoomMax25, RoomMax50, RoomMax75; // Set % of MaxRoom
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        float StartTime = RoomMax * 2 * 0.3f;
        Invoke("SpawnExitDooROrBoss", StartTime);
    }

    public  GameObject GetRandomPoint(int Direction)
    {
        AllPoint CurrentPoint = GetPoint(Direction);
        if (RoomList.Count <= RoomMax25)
        {
            return CurrentPoint.AllDirectionPoint[3].APoint[Random.Range(0, CurrentPoint.AllDirectionPoint[0].APoint.Count)].RoomPrefab;
        }
        if (RoomList.Count <= RoomMax50 && RoomList.Count > RoomMax25)
        {
            return CurrentPoint.AllDirectionPoint[2].APoint[Random.Range(0, CurrentPoint.AllDirectionPoint[0].APoint.Count)].RoomPrefab;

        }
        if (RoomList.Count <= RoomMax75 && RoomList.Count > RoomMax25)
        {
            return CurrentPoint.AllDirectionPoint[1].APoint[Random.Range(0, CurrentPoint.AllDirectionPoint[0].APoint.Count)].RoomPrefab;

        }
        if(RoomList.Count >= RoomMax )
        {
            return CurrentPoint.AllDirectionPoint[0].APoint[Random.Range(0, CurrentPoint.AllDirectionPoint[0].APoint.Count)].RoomPrefab;
        }
       
        return null;
    }

    void SpawnExitDooROrBoss()
    {
        Instantiate(ExitDoor, RoomList[RoomList.Count - 1].transform.position, Quaternion.identity);
    }
  

    public GameObject GetRoomByID(int value)
    {
        return Allpoint.APoint.FirstOrDefault(i => value == i.PointID).RoomPrefab;
    }

   public SpawnRoom GetPath(int value)
    {
        return PahtList[value];
    }

    public AllPoint GetPoint(int value)
    {
        return allALivablePoint.FirstOrDefault(i => i.Diction == value);
    }


    public GameObject GetWall(int value)
    {
        return Wall[value];
    }
    
        
} 
