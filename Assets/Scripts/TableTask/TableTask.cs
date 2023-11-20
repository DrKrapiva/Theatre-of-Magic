using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTask : MonoBehaviour
{
    [SerializeField] private Transform panelSafe;
    [SerializeField] private Transform canvas;
    [SerializeField] private GameObject panelClue;
    public void ClosePanel()
    {
        if (gameObject != null)
            GameController.Instance.ClosePanel(gameObject);
    }
    public void OpenEnvelope()
    {
        GameController.Instance.OpenLetter();
    }
    public void OpenSafePanel()
    {
        Transform panelSafee = Instantiate(panelSafe, canvas, false);
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
