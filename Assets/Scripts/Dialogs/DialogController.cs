using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : DialogsDictionary
{
    private int _dialogIdStart;
    private int _dialogIdFinish;
    public static DialogController Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;

    }
    static private DialogController _instance;
    public void StartDialog()
    {
        _dialogIdStart = dicDialogsNumber[Save.Instance.LoadGameNumber("SaveDialogNumber")].DialogIdStart;
        _dialogIdFinish = dicDialogsNumber[Save.Instance.LoadGameNumber("SaveDialogNumber")].DialogIdEnd;

        DialogShow.Instance.GetDialog(_dialogIdStart, _dialogIdFinish);
       // gameObject.GetComponent<DialogShow>().GetDialog(_dialogIdStart, _dialogIdFinish);
        SaveNumberDialog();
    }

    private void SaveNumberDialog()
    {
        Save.Instance.SaveGameNumber(Save.Instance.LoadGameNumber("SaveDialogNumber") + 1, "SaveDialogNumber");
    }
}
