using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSlot : MonoBehaviour
{
    [SerializeField] private Image imageObjectSlot;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<DragSlot>() != null && gameObject.name == collision.name)
        {
            
               // Debug.Log("yes");
                imageObjectSlot.enabled = true;
                imageObjectSlot.GetComponent<Image>().sprite = Resources.Load<Sprite>("Foyer/Paintings/" + gameObject.name);
                Destroy(collision.gameObject);
            

            PaintingsTask.Instance.WinTask();
        } 

    }
}
