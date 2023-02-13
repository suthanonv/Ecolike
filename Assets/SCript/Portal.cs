using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Portal : MonoBehaviour
{
    [SerializeField] float ActiveRange;
    [SerializeField] GameObject Panel;
    [SerializeField] KeyCode ActiveKey;
    [SerializeField] TextMeshPro UiText;
    Transform Player;
    private void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        SetUiText();
    }

    private void Update()
    {
       if(Vector2.Distance(this.transform.position, Player.transform.position) <=ActiveRange)
        {
            Panel.SetActive(true);
            if(Input.GetKeyDown(ActiveKey))
            {
                RanDuengeon.instance.newDuengeonGenerat();
                Destroy(this.gameObject);
            }
        }
        else
        {
            Panel.SetActive(false);

        }
    }

    public void SetUiText()
    {
        UiText.text = "Prees " + ActiveKey.ToString() + " To Next Stage";
    }
}
