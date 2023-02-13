using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawningItem : MonoBehaviour
{
    [SerializeField] Transform Point1, Point2;
    [SerializeField] int MaxSpawnLimit;
    

    public float DelayTime;
    private void Start()
    {

        SpawnItem();
    }

    void SpawnItem()
    {
        int CurrentSpawnLimit = 0;
        while (CurrentSpawnLimit < MaxSpawnLimit)
        {
            Vector2 Rand = new Vector2(Random.Range(Point1.transform.position.x, Point2.transform.position.x), Random.Range(Point2.transform.position.y, Point1.transform.position.y));
            GameObject RoomItems = Instantiate(Roomtemeplete.instance.GetRooomItem(), Rand, Quaternion.identity);
            RoomItems.transform.parent = this.transform;
            CurrentSpawnLimit++;
        }
    }

}
