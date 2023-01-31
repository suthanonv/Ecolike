using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCount : MonoBehaviour
{
    private void Start()
    {
        Roomtemeplete.instance.RoomList.Add(this.gameObject);
    }
}
