using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform panelPaintingsTask;
    [SerializeField] private Transform panelLampTask;
    [SerializeField] private Transform canvas;
    [SerializeField] private Transform panelEnvelope;
    [SerializeField] private Transform panelBarTask;
    [SerializeField] private Transform panelTableTask;
    [SerializeField] private Transform panelTicket;
    [SerializeField] private Transform imageHall;
    [SerializeField] private Transform panelDialog;

    [SerializeField] private GameObject buttonPaintings;
    [SerializeField] private GameObject buttonBar;
    [SerializeField] private GameObject panelStart;


    public static GameController Instance
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
    static private GameController _instance;
    private void Start()
    {
       
    }
    public void OpenPaintingsTask()
    {
        Transform panelPaintings = Instantiate(panelPaintingsTask, canvas, false);
    }
    public void ClosePanel(GameObject panel)
    {
        Destroy(panel);
    }
    public void OpenLampTask()
    {
        Transform panelLamp = Instantiate(panelLampTask, canvas, false);
    }
    public void OpenBarTask()
    {
        Transform panelBar = Instantiate(panelBarTask, canvas, false);
    }
    public void OpenTableTask()
    {
        Transform panelTable = Instantiate(panelTableTask, canvas, false);
    }
    
    public void OpenLetter()
    {
        Transform panelEnvelopee = Instantiate(panelEnvelope, canvas, false);
    }
    public void OpenTicket()
    {
        Transform panelTickett = Instantiate(panelTicket, canvas, false);
    }
    public void OpenImageHall()
    {
        Transform imageHalll = Instantiate(imageHall, canvas, false);
    }
    public void SaveTaskNumber(int number, string nameSave)
    {
        Save.Instance.SaveGameNumber(number, nameSave);
    }
    public int LoadTaskNumber(string nameSave)
    {
        return Save.Instance.LoadGameNumber(nameSave);
    }
    public bool CheckIsInteractableTask(int task)
    {
        return LoadTaskNumber("SaveTaskNumber") >= task;
    }

    public void DestroyButtonPaintings()
    {
        Destroy(buttonPaintings);
    }
    public void DestroyButtonBar()
    {
        Destroy(buttonBar);
    }
    public void GenerateDialog()
    {
        Transform panelDialogg = Instantiate(panelDialog, canvas, false);
    } 
    public void ClosePanelStart()
    {
        Destroy(panelStart);
    }
}
