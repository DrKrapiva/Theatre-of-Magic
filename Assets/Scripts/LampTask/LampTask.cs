using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LampTask : MonoBehaviour
{
    private List<GameObject> lampBulbs = new List<GameObject>();
    private List<Transform> targetSpots = new List<Transform>();
    private string correctPositionName = "Spot3";
    private bool isVictoryLogged = false;
    [SerializeField] private Image chest;
    private int taskNumber = 2;
    [SerializeField] private GameObject panelClue;
    public static LampTask Instance
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
    static private LampTask _instance;

    void Start()
    {
        FindAndAddLampBulbs();
        FindAndAddTargetSpots();

    }
    private void Update()
    {
        if (!isVictoryLogged) 
        { 
            if (AreAllLumpBulbsInCorrectPosition(correctPositionName))
            {
                Win();
                isVictoryLogged = true;
            }
        }
        if (isVictoryLogged)
        {
            if (Input.GetMouseButtonDown(0)) // Проверяем нажатие левой кнопки мыши
            {
                ClosePanel();//заменить на загрузку новой сцены
                Debug.Log("win");
            }
        }
    }
    private void FindAndAddLampBulbs()
    {
        GameObject[] lampBulb = FindObjectsOfType<GameObject>();

        foreach (GameObject slot in lampBulb)
        {
            if (slot.GetComponent<LaserBeam>() != null)
                lampBulbs.Add(slot);
        }

    }
    private void FindAndAddTargetSpots()
    {
        Transform[] spots = FindObjectsOfType<Transform>();

        foreach (Transform slot in spots)
        {
            if (slot.GetComponent<TargetSpot>() != null)
                targetSpots.Add(slot);
        }

    }
    public Transform GiveTargetSpot()
    {
        int randomIndex = Random.Range(0, targetSpots.Count );
        return targetSpots[randomIndex];
    }

    public Transform GiveNewTargetSpot(Transform spot)
    {
        int index = targetSpots.IndexOf(spot);
        if (index == targetSpots.Count - 1)
        {
            return targetSpots[0];
        }
        else
        {
            return targetSpots[index + 1];
        }
    }
    private bool AreAllLumpBulbsInCorrectPosition(string correctPositionName)
    {
        foreach(var lamp in lampBulbs)
        {
            if(lamp.GetComponent<LaserBeam>().Target.name != correctPositionName)
            {
                return false;
            }
            
        }
        return true;
    }
    private void Win()
    {
        chest.sprite = Resources.Load<Sprite>("Foyer/lamp/openChest");
        GameController.Instance.SaveTaskNumber(taskNumber, "SaveTaskNumber");
        //load new scene
        // SceneLoader.Instance.LoadNewScene(1);
       // StartCoroutine(DelayedExecution());
        SceneLoader.Instance.LoadNewScene(1);
    }
    IEnumerator DelayedExecution()
    {
        yield return new WaitForSeconds(0.5f); // Задержка на 5 секунд

        SceneLoader.Instance.LoadNewScene(1);
    }
    public void ClosePanel()
    {
        Destroy(gameObject);
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
