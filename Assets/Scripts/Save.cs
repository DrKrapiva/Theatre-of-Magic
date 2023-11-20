using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

class SaveNumber
{
    public int Number;
}
    public class Save : MonoBehaviour
{
    public static Save Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
        //NewGame();
        //LoadCorrectScene();
    }
    static private Save _instance;
    public void NewGame()
    {
        SaveGameNumber(0, "SaveTaskNumber");
        SaveGameNumber(1, "SaveDialogNumber");
        SaveGameNumber(1, "SaveLetterNumber");
        GameController.Instance.GenerateDialog();
    }
    public void SaveGameNumber(int number, string nameSave)
    {
        SaveNumber save = new SaveNumber() { Number = number};
        SaveSystem.Set(nameSave, save);
    }
    public int LoadGameNumber(string nameSave)
    {
        return   SaveSystem.Get<SaveNumber>(nameSave).Number;
    }
   /* private void LoadCorrectScene()
    {
        //Debug.Log(LoadTaskNumber());
        switch (LoadGameTaskNumber())
        {
            case 0:
                SceneLoader.Instance.LoadNewScene(0);
                break;
            case 2:
                SceneLoader.Instance.LoadNewScene(1);
                break;
            case 4:
                SceneLoader.Instance.LoadNewScene(2);
                break;
            default:
                //Debug.Log("Unknown task");
                break;
        }
    }*/
}
