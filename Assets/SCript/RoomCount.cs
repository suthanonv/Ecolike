using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCount : MonoBehaviour
{
    [SerializeField] Transform Point1, Point2;
    [SerializeField] int MaxSpawnLimit;
    [SerializeField] bool IsSpawnRoom = false;

    public float DelayTime;
    private void Start()
    {
        Roomtemeplete.instance.RoomList.Add(this.gameObject);
        SpawnItem();
        SpawnEnemy();
    }

     void SpawnItem()
    {
        int CurrentSpawnLimit = 0;
        while(CurrentSpawnLimit < MaxSpawnLimit)
        {
            Vector2 Rand = new Vector2(Random.Range(Point1.transform.position.x, Point2.transform.position.x), Random.Range(Point2.transform.position.y, Point1.transform.position.y));
      GameObject RoomItems =  Instantiate(Roomtemeplete.instance.GetRooomItem(), Rand, Quaternion.identity);
            RoomItems.transform.parent = this.transform;
            CurrentSpawnLimit++;
        }
    }

    void SpawnEnemy()
    {
        int CurrentEnemySpawn = 0;
        int MaxSpawn = Roomtemeplete.instance.GetEnemySpawnLimit();
      
        if (!IsSpawnRoom)
        {
            while(CurrentEnemySpawn < MaxSpawn)
            {
                Vector2 Rand = new Vector2(Random.Range(Point1.transform.position.x, Point2.transform.position.x), Random.Range(Point2.transform.position.y, Point1.transform.position.y));
           GameObject enumy  = Instantiate(Roomtemeplete.instance.GetEnemy(), Rand, Quaternion.identity);
                enumy.transform.parent = this.transform;         
                CurrentEnemySpawn++;
          
            }
        }
    }
}
