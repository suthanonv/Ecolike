using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
public class Roomtemeplete : MonoBehaviour
{
    public static Roomtemeplete instance;
    [SerializeField] int RoomMax;
    [SerializeField] public List<GameObject> RoomList;
    [SerializeField] PointList Allpoint;
    [SerializeField] List<AllPoint> allALivablePoint = new List<AllPoint>();
    public SpawnRoom[] PahtList;
    public GameObject[] Wall;
    [SerializeField] List<GameObject> RoomItem = new List<GameObject>();
    [SerializeField] List<GameObject> PathItem = new List<GameObject>();
    [SerializeField] GameObject ExitDoor;

    [SerializeField] int RoomMax25, RoomMax50, RoomMax75; // Set % of MaxRoom
    int OnFloor = 0;
    int CurrentFloor;
    bool OnLoad;

    private void Awake()
    {
        instance = this;
        
    }

    [SerializeField] float StartTime = 4f;

    [SerializeField] GameObject LoadPanal;
    private void Start()
    {
        OnLoad = true;
        PlayerWalk.instance.OnWarping(true);
        Invoke("SpawnExitDooROrBoss", StartTime);
    }

    private void Update()
    {
        if(OnLoad)
        {
            LoadPanal.SetActive(true);
        }
        else
        {
            LoadPanal.SetActive(false);
        }
    }

    public  GameObject GetRandomPoint(int Direction)
    {
        AllPoint CurrentPoint = GetPoint(Direction);
        if (RoomList.Count <= RoomMax25)
        {
            return CurrentPoint.AllDirectionPoint[3].APoint[UnityEngine.Random.Range(0, CurrentPoint.AllDirectionPoint[0].APoint.Count)].RoomPrefab;
        }
        if (RoomList.Count <= RoomMax50 && RoomList.Count > RoomMax25)
        {
            return CurrentPoint.AllDirectionPoint[2].APoint[UnityEngine.Random.Range(0, CurrentPoint.AllDirectionPoint[0].APoint.Count)].RoomPrefab;

        }
        if (RoomList.Count <= RoomMax75 && RoomList.Count > RoomMax25)
        {
            return CurrentPoint.AllDirectionPoint[1].APoint[UnityEngine.Random.Range(0, CurrentPoint.AllDirectionPoint[0].APoint.Count)].RoomPrefab;

        }
        if(RoomList.Count >= RoomMax )
        {
            return CurrentPoint.AllDirectionPoint[0].APoint[UnityEngine.Random.Range(0, CurrentPoint.AllDirectionPoint[0].APoint.Count)].RoomPrefab;
        }
       
        return null;
    }

    void SpawnExitDooROrBoss()
    {
      
        Instantiate(ExitDoor, RoomList[RoomList.Count - 1].transform.position, Quaternion.identity);
        PlayerWalk.instance.OnWarping(false);
        OnLoad = false;
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

    public GameObject GetRooomItem()
    {
        return RoomItem[UnityEngine.Random.Range(0, RoomItem.Count)];
    }

    public GameObject GetPathItem()
    {
        return PathItem[UnityEngine.Random.Range(0, PathItem.Count)];
    }

    public GameObject GetWall(int value)
    {
        return Wall[value];
    }
    [SerializeField] List<EnemyList> allEnemy = new List<EnemyList>();
    public GameObject GetEnemy()
    {
        EnemyList currentList = allEnemy.FirstOrDefault(i => i.CurrentLv == OnFloor);
        return currentList.AllEnemyOnFloor.FirstOrDefault(i => i.CurrentFloor == CurrentFloor).AlvibleEnemy[UnityEngine.Random.Range(0, currentList.AllEnemyOnFloor.FirstOrDefault(i => i.CurrentFloor == CurrentFloor).AlvibleEnemy.Count)];
    }
       
    public int GetEnemySpawnLimit()
    {
       EnemyList currentList = allEnemy.FirstOrDefault(i => i.CurrentLv == OnFloor);
        Floor floorRand = currentList.AllEnemyOnFloor.FirstOrDefault(i => i.CurrentFloor == CurrentFloor);
        return UnityEngine.Random.Range(floorRand.MinSpawn, floorRand.MaxSpawn);
    }


    public void RandNewDuengeon()
    {
        foreach(GameObject  i in RoomList)
        {
            Destroy(i);
        }
        OnLoad = true;
        CurrentFloor++;
        RoomList = new List<GameObject>();
        EnemyList currentList = allEnemy.FirstOrDefault(i => i.CurrentLv == OnFloor);
        Floor floorRand = currentList.AllEnemyOnFloor.FirstOrDefault(i => i.CurrentFloor == CurrentFloor);
        RoomMax = floorRand.MaxSpawnRoom;
        RoomMax25 = floorRand.Precent25;
        RoomMax50 = floorRand.Percent50;
        RoomMax75 = floorRand.Percent75;
        Invoke("SpawnExitDooROrBoss", StartTime);
    }
} 
[Serializable]
public class EnemyList
{
    public int CurrentLv;
    public List<Floor> AllEnemyOnFloor;
}
[Serializable]
public class Floor
{
    public float StartingSpawnPotalTime;
    public int CurrentFloor;
    public int MaxSpawnRoom;
    public int Precent25, Percent50, Percent75;
    public int MaxSpawn, MinSpawn;
    public List<GameObject> AlvibleEnemy = new List<GameObject>(); 
}

