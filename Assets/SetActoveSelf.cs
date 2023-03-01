using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActoveSelf : MonoBehaviour
{
   public void SetActiveSelfTrue()
    {
        this.gameObject.SetActive(false);
    }

    public void SetActiveSelfFalse()
    {
        this.gameObject.SetActive(true);
    }
}
