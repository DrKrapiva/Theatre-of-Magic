using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotForNumber : MonoBehaviour
{
    private List<string> listNumberNames = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    int index = 0;
    void Start()
    {
        LoadImage();
    }
    private void LoadImage()
    {
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Buffet/Table/" + listNumberNames[index]);
        //отправить индекс в панель
        PanelSafe.Instance.AddNumberToListInputNumber(gameObject.name, index);
    }
    public void Left()
    {
        if(index == 0)
        {
            index = 9;
        }
        else
        {
            index--;
        }
        LoadImage();
    }
    public void Right()
    {
        if(index == 9)
        {
            index = 0;
        }
        else
        {
            index++;
        }
        LoadImage();
    }
}
