using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteOrder : MonoBehaviour
{

    public static ChangeSpriteOrder instacne;

    [SerializeField] SpriteRenderer render;
    [SerializeField] int UpChange;
    [SerializeField] int DownChange;


    private void Awake()
    {
        instacne = this;
    }

    public void ChangeDownPoint()
    {
        render.sortingOrder = DownChange;
    }

    public void ChangeUpPoint()
    {
        render.sortingOrder = UpChange;
    }

}
