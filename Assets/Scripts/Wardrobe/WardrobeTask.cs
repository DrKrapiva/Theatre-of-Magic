using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WardrobeTask : MonoBehaviour
{
    private List<GameObject> slotsCloth = new List<GameObject>();
    private List<string> listCorrectCloth = new List<string>() { "green", "blue", "red", "yellow" };
    private List<string> listCloth = new List<string>() { "", "", "", "" };
    private int taskNumber = 5;
    [SerializeField] private GameObject panelClue;
    public static WardrobeTask Instance
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
    static private WardrobeTask _instance;
    void Start()
    {
        FindAddNumberSlots();
        do
        {
            RandomeAndAddToListCloth();
        } while (AreListsEqual(listCloth, listCorrectCloth));
        
    }
    private void FindAddNumberSlots()
    {
        //Find
        GameObject[] slotCloth = FindObjectsOfType<GameObject>();

        // sort list by x.position
        List<GameObject> slotsClothh = new List<GameObject>();

        foreach (GameObject slot in slotCloth)
        {
            if (slot.GetComponent<ClothSlot>() != null)
            {
                slotsClothh.Add(slot);
            }
        }
        slotsClothh.Sort((a, b) => a.transform.position.x.CompareTo(b.transform.position.x));

        //AddSlots
        slotsCloth.Clear();

        //int i = 0;
        foreach (GameObject slot in slotsClothh)
        {

            if (slot.GetComponent<ClothSlot>() != null)
            {
                //i++;
                //slot.name = slot.name + i;
                slotsCloth.Add(slot);
                //Debug.Log(slot.name);
            }
        }
    }
    private void RandomeAndAddToListCloth()
    {
        List<string> tempList = new List<string>(listCorrectCloth);
        listCloth.Clear();

        while (tempList.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, tempList.Count);
            listCloth.Add(tempList[randomIndex]);
            tempList.RemoveAt(randomIndex);
        }
        LoadImage();
    }
    bool AreListsEqual(List<string> list1, List<string> list2)
    {
        for (int i = 0; i < list1.Count; i++)
        {
            if (list1[i] != list2[i])
                return false;
        }
        return true;
    }
    private void LoadImage()
    {
        for (int i = 0; i < slotsCloth.Count; i++)
        {
            slotsCloth[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Wardrobe/" + listCloth[i]);
            slotsCloth[i].name = listCloth[i];
        }
    }
    public void ChangeSlots(string nameWhoTouched, string nameWhoWasTouched)
    {
        int index = slotsCloth.FindIndex(obj => obj.name == nameWhoWasTouched);
        int ind = slotsCloth.FindIndex(obj => obj.name == nameWhoTouched);

        listCloth[ind] = nameWhoWasTouched;
        slotsCloth[index].GetComponent<Image>().sprite = Resources.Load<Sprite>("Wardrobe/" + nameWhoTouched);


        listCloth[index] = nameWhoTouched;
        slotsCloth[ind].GetComponent<Image>().sprite = Resources.Load<Sprite>("Wardrobe/" + nameWhoWasTouched);
        

        CheckWin();
    }
    private void CheckWin()
    {
        
        if(AreListsEqual(listCloth, listCorrectCloth))
        {
            Win();
        }
    }
    private void Win()
    {
        GameController.Instance.SaveTaskNumber(taskNumber, "SaveTaskNumber");
        GameController.Instance.OpenTicket();
    }
    public void OpenClue()
    {
        panelClue.SetActive(true);
    }
    public void CloseClue()
    {
        panelClue.SetActive(false);
    }
}
