using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wineglass : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<DragSlot>() != null )
        {

             Debug.Log("yes");
            BarTask.Instance.CheckCorrertNameAndLoadImage(collision.name);
        }

    }
}
