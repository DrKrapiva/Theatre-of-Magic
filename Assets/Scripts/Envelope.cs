using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Envelope : MonoBehaviour
{
    [SerializeField] private Transform panelLetter;
    [SerializeField] private Transform canvas;
    public void ClickEnvelope()
    {
        Transform panelLetterClon = Instantiate(panelLetter, canvas, false);

        int letterNumber = Save.Instance.LoadGameNumber("SaveLetterNumber");
        //получать цифру из сохранения
        panelLetterClon.GetComponent<Letter>().ShowText(letterNumber);

        
    }
    public void ClosePanel()
    {
        GameController.Instance.ClosePanel(gameObject);
    }
}
