using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawning : MonoBehaviour
{
    public int NeedDirection;
    SpawnRoom Path;
    bool Spawn = false;


    private void Start()
    {
        Invoke("Spawns", 0.1f);
    }

    public void Spawns()
    {

        if (Spawn == false)
        {
            Path = Roomtemeplete.instance.GetPath(NeedDirection);
          SpawnRoom Paths =  Instantiate(Path, this.transform.position, Path.transform.rotation);
            
            Spawn = true; 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.CompareTag("Path"))
        {
            Destroy(this.gameObject);
        }
    }

}
