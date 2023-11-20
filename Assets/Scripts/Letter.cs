using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Letter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI letterText;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Проверяем нажатие левой кнопки мыши
        {
            transform.parent.GetComponent<Envelope>().ClosePanel();
        }
    }

    
    public void ShowText(int letterNumber) {
        switch (letterNumber)
        {
            case 1:
                Debug.Log("1");
                letterText.text = "Pour into the bowl a laughter bright,\r\nEchoing joy in the heart's light.\r\nThen add the warmth of love's pure sight,\r\nA feeling that makes the world so right.\r\n\r\nNext comes the secret of the night,\r\nA poison hidden, out of sight.\r\nAnd for the potion to take flight,\r\nAdd a drop of orange, sunny and bright.";  
                break;
            case 2:
                Debug.Log("2");
                letterText.text = "In a theater of magic, under moon's light,\r\nThe unicorn stands first, a majestic sight.\r\nFollowed by plates in a neat, shiny row,\r\nThen apples red as dawn's early glow.\r\n\r\nBananas conclude the count with a beam,\r\nCount carefully to unlock the dream.\r\nIn this game of mystery and magic lure,\r\nThe count's the key to secrets obscure.";
                break;
            default:
                break;
        } }

}
