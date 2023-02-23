using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    Transform Player;
    [SerializeField] float EnemeySpawnTime;
    [SerializeField] float SpawnRange;

    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        StartCoroutine(countdown());
    }

    // Update is called once per frame
    IEnumerator countdown()
    {
        while (true)
        {
            yield return new WaitForSeconds(EnemeySpawnTime);
            Instantiate(Enemy, GetPoint(), Quaternion.identity);
        }
    }

    Vector2 GetPoint()
    {
        return new Vector2(Player.transform.position.x + RandBetweenTwoNum(SpawnRange), Player.transform.position.y + RandBetweenTwoNum(SpawnRange));
    }

    float RandBetweenTwoNum(float num)
    {
        if(Random.Range(0,2) == 1)
        {
            return -num;
        }
        return num;
    }


}