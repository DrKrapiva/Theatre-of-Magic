using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTicket : MonoBehaviour
{
    public void LoadImageHall()
    {
         Debug.Log("win");
      // Save.Instance.SaveGameNumber(2, "SaveDialogNumber");
        GameController.Instance.GenerateDialog();
        DialogController.Instance.StartDialog();
    }

}
