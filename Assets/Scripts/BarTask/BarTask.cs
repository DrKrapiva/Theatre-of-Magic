using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BarTask : MonoBehaviour
{
    private List<string> listDragObjectsNames = new List<string>() { "anger", "apple", "cold", "laughter", "love", "luck", "orange", "poison" };
    private List<string> listDragCorrectNames = new List<string>() { "laughter", "love", "poison", "orange" };
    private List<GameObject> slotsDragObjects = new List<GameObject>();
    private List<GameObject> slotsQueations = new List<GameObject>();
    private int index = 0;
    private int taskNumber = 3;
    [SerializeField] private GameObject panelClue;
    public static BarTask Instance
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
    static private BarTask _instance;
    private void Start()
    {
        FindAndAddSlotsDragObjects();
        AssignUniqueImages();
        FindAddRenameQuestionSlots();
    }
    private void FindAndAddSlotsDragObjects()
    {
        GameObject[] slotsDrad = FindObjectsOfType<GameObject>();

        foreach (GameObject slot in slotsDrad)
        {
            if (slot.GetComponent<DragSlot>() != null)
                slotsDragObjects.Add(slot);
        }

    }
    private void FindAddRenameQuestionSlots()
    {
        //Find
        GameObject[] slotQuestion = FindObjectsOfType<GameObject>();

        // sort list by x.position
        List<GameObject> slotQuestionList = new List<GameObject>();

        foreach (GameObject slot in slotQuestion)
        {
            if (slot.GetComponent<SlotQuestion>() != null)
            {
                slotQuestionList.Add(slot);
            }
        }
        slotQuestionList.Sort((a, b) => a.transform.position.x.CompareTo(b.transform.position.x));

        //AddRenameQuestionSlots
        slotsQueations.Clear();

        foreach (GameObject slot in slotQuestionList)
        {
            if(slot.GetComponent<SlotQuestion>() != null)
            {
                slot.name = "question";
                slotsQueations.Add(slot);
            }
        }
    }
    private void AssignUniqueImages()
    {
        foreach (GameObject slot in slotsDragObjects)
        {
            if (listDragObjectsNames.Count > 0)
            {
                int randomIndex = Random.Range(0, listDragObjectsNames.Count );
                string imageName = listDragObjectsNames[randomIndex];
                slot.GetComponent<Image>().sprite = Resources.Load<Sprite>("Buffet/Bar/" + imageName);
                slot.name = imageName;
                listDragObjectsNames.Remove(imageName);
            }
        }
    }

    public void ClosePanel()
    {
        if (gameObject != null)
            GameController.Instance.ClosePanel(gameObject);
    }
    public void CheckCorrertNameAndLoadImage(string enteredName)
    {
        if(index == 4)
        {
            index = 0;
        }
        if (listDragCorrectNames[index] == enteredName)
            {
                slotsQueations[index ].GetComponent<Image>().sprite = Resources.Load<Sprite>("Buffet/Bar/CheckMark");
                slotsQueations[index ].name = "true";
                Debug.Log(slotsQueations[index ].name);
            }
        else
            {
                slotsQueations[index].GetComponent<Image>().sprite = Resources.Load<Sprite>("Buffet/Bar/XMark");
                slotsQueations[index ].name = "false";
                Debug.Log(slotsQueations[index].name);
            }
        if(index == 3)
        {
            CheckWin();
        }
        index++;
    }
    public void ClearWineglass()
    {
        index = 0;
        foreach(var slot in slotsQueations)
        {
            slot.GetComponent<Image>().sprite = Resources.Load<Sprite>("Buffet/Bar/QuestionMark");
        }
    }
    public void OpenEnvelope()
    {
        GameController.Instance.OpenLetter();
    }
    private void CheckWin()
    {
        foreach (GameObject obj in slotsQueations)
        {
            if (obj.name != "true")
            {
                return; 
            }
        }
        Win();
    }
    private void Win()
    {
        GameController.Instance.OpenLetter();
        GameController.Instance.SaveTaskNumber(taskNumber, "SaveTaskNumber");
        GameController.Instance.DestroyButtonBar();
        Save.Instance.SaveGameNumber(Save.Instance.LoadGameNumber("SaveLetterNumber") + 1, "SaveLetterNumber");
        ClosePanel();
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
