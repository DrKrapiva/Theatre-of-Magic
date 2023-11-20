using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PaintingsTask : MonoBehaviour
{
    private List<string> listDragObjectsNames = new List<string>() { "Apple", "LeftEye", "Necklace1", "Necklace2", "Necklace3", "RightEye" };
    private List<GameObject> slotsDragObjects = new List<GameObject>();
    private int metch = 0;
    private int taskNumber = 1;
    [SerializeField] private Transform panelEnvelope;
    [SerializeField] private Transform canvas;
    [SerializeField] private GameObject panelClue;
    public static PaintingsTask Instance
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
    static private PaintingsTask _instance;

    
    private void Start()
    {
        FindAndAddSlotsDragObjects();
        AssignUniqueImages();
    }
    public void ClosePanel()
    {
        if(gameObject != null)
             GameController.Instance.ClosePanel(gameObject);
    }
    private void FindAndAddSlotsDragObjects()
    {
        GameObject[] slotsDrad = FindObjectsOfType<GameObject>();

        foreach(GameObject slot in slotsDrad)
        {
            if(slot.GetComponent<DragSlot>() != null)
                slotsDragObjects.Add(slot);
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
                slot.GetComponent<Image>().sprite = Resources.Load<Sprite>("Foyer/Paintings/" + imageName);
                slot.name = imageName;
                listDragObjectsNames.Remove(imageName);
            }
        }
    }
    public void WinTask()
    {
        metch++;
        if(metch >= 4)
        {
            GameController.Instance.OpenLetter();
            GameController.Instance.SaveTaskNumber(taskNumber, "SaveTaskNumber");
            GameController.Instance.DestroyButtonPaintings();
            ClosePanel();
        }
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
