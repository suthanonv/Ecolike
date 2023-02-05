using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCount : MonoBehaviour
{
    [SerializeField] Transform Point1, Point2;
    [SerializeField] int MaxSpawnLimit;
    private void Start()
    {
        Roomtemeplete.instance.RoomList.Add(this.gameObject);
        SpawnItem();
    }

     void SpawnItem()
    {
        int CurrentSpawnLimit = 0;
        while(CurrentSpawnLimit < MaxSpawnLimit)
        {
            Vector2 Rand = new Vector2(Random.Range(Point1.transform.position.x, Point2.transform.position.x), Random.Range(Point2.transform.position.y, Point1.transform.position.y));
            Instantiate(Roomtemeplete.instance.GetRooomItem(), Rand, Quaternion.identity);
            CurrentSpawnLimit++;
        }
    }
}
