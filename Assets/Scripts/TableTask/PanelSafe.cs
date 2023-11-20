using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PanelSafe : MonoBehaviour
{
    private List<int> listCorrectNumber = new List<int>() { 1, 6, 3, 4 };
    private List<int> listInputNumber = new List<int>() { 0,0,0,0};
    private List<GameObject> slotsNumber = new List<GameObject>();
    private List<GameObject> buttonLeft = new List<GameObject>();
    private List<GameObject> buttonRight = new List<GameObject>();
    private int index = 0;
    private int taskNumber = 4;
    public static PanelSafe Instance
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
    static private PanelSafe _instance;
    private void Start()
    {
        FindAddNumberSlots();
        FindAddLeftButton();
        FindAddRightButton();
    }
    public void ClosePanel()
    {
        if (gameObject != null)
            GameController.Instance.ClosePanel(gameObject);
    }
    private void FindAddNumberSlots()
    {
        //Find
        GameObject[] slotNumber = FindObjectsOfType<GameObject>();

        // sort list by y.position
        List<GameObject> slotsNumberr = new List<GameObject>();

        foreach (GameObject slot in slotNumber)
        {
            if (slot.GetComponent<SlotForNumber>() != null)
            {
                slotsNumberr.Add(slot);
            }
        }
        slotsNumberr.Sort((a, b) => b.transform.position.y.CompareTo(a.transform.position.y));

        //AddSlots
        slotsNumber.Clear();

        int i = 0;
        foreach (GameObject slot in slotsNumberr)
        {

            if (slot.GetComponent<SlotForNumber>() != null)
            {
                i++;
                slot.name = slot.name + i;
                slotsNumber.Add(slot);
                //Debug.Log(slot.name);
            }
        }
    }
    private void FindAddLeftButton()
    {
        //Find
        GameObject[] leftButton = FindObjectsOfType<GameObject>();

        // sort list by y.position
        List<GameObject> buttonLeftt = new List<GameObject>();

        foreach (GameObject slot in leftButton)
        {
            if (slot.GetComponent<LeftArrow>() != null)
            {
                buttonLeftt.Add(slot);
            }
        }
        buttonLeftt.Sort((a, b) => b.transform.position.y.CompareTo(a.transform.position.y));

        //AddSlots
        buttonLeft.Clear();

        int i = 0;
        foreach (GameObject slot in buttonLeftt)
        {

            if (slot.GetComponent<LeftArrow>() != null)
            {
                i++;
                slot.name = slot.name + i;
                buttonLeft.Add(slot);
               // Debug.Log(slot.name);
            }
        }
    }
    private void FindAddRightButton()
    {
        //Find
        GameObject[] rightButton = FindObjectsOfType<GameObject>();

        // sort list by y.position
        List<GameObject> buttonRightt = new List<GameObject>();

        foreach (GameObject slot in rightButton)
        {
            if (slot.GetComponent<RightArrow>() != null)
            {
                buttonRightt.Add(slot);
            }
        }
        buttonRightt.Sort((a, b) => b.transform.position.y.CompareTo(a.transform.position.y));

        //AddSlots
        buttonRight.Clear();

        int i = 0;
        foreach (GameObject slot in buttonRightt)
        {

            if (slot.GetComponent<RightArrow>() != null)
            {
                i++;
                slot.name = slot.name + i;
                buttonRight.Add(slot);
               // Debug.Log(slot.name);
            }
        }
    }
    public void GetIndexInListLeft(string nameLeftButton)
    {
        index = buttonLeft.FindIndex(obj => obj.name == nameLeftButton);
        LoadImageNumberLeft();
    }
    private void LoadImageNumberLeft()
    {
        slotsNumber[index].GetComponent<SlotForNumber>().Left();
    }
    public void GetIndexInListRight(string nameRightButton)
    {
        index = buttonRight.FindIndex(obj => obj.name == nameRightButton);
        LoadImageNumberRight();
    }
    private void LoadImageNumberRight()
    {
        slotsNumber[index].GetComponent<SlotForNumber>().Right();
    }
    public void AddNumberToListInputNumber(string slotName, int inputNumber)
    {
        int ind = slotsNumber.FindIndex(obj => obj.name == slotName);
        listInputNumber[ind] = inputNumber;
        CheckWin();
    }
    private void CheckWin()
    {
        if (listCorrectNumber.SequenceEqual(listInputNumber))
        {
            Win();
        }
    }
    private void Win()
    {
        GameController.Instance.SaveTaskNumber(taskNumber, "SaveTaskNumber");
        //load new scene
        SceneLoader.Instance.LoadNewScene(2);
    }
}
