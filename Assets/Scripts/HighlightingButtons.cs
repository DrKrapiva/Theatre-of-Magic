using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightingButtons : MonoBehaviour
{

    [SerializeField] private GameObject buttonTask1;
    [SerializeField] private GameObject buttonTask2;
    [SerializeField] private GameObject buttonEnvelope;
    private Outline outlineTask1;
    private Outline outlineTask2;
    private Outline outlineEnvelope;
    private void Start()
    {
        outlineTask1 = buttonTask1.GetComponent<Outline>();
        outlineTask2 = buttonTask2.GetComponent<Outline>();
        outlineEnvelope = buttonEnvelope.GetComponent<Outline>();
    }
    public void OnPointerEnterTask1()
    {
        if (outlineTask1 != null)
            outlineTask1.effectColor = Color.red; // Изменение цвета обводки
    }
    public void OnPointerExitTask1()
    {
        if (outlineTask1 != null)
            outlineTask1.effectColor = Color.white; // Возвращение к исходному цвету
    }
    public void OnPointerEnterTask2()
    {
        if (outlineTask2 != null)
            outlineTask2.effectColor = Color.red; // Изменение цвета обводки
    }
    public void OnPointerExitTask2()
    {
        if (outlineTask2 != null)
            outlineTask2.effectColor = Color.white; // Возвращение к исходному цвету
    }
    public void OnPointerEnterEnvelope()
    {
        if (outlineEnvelope != null)
            outlineEnvelope.effectColor = Color.red; // Изменение цвета обводки
    }
    public void OnPointerExitEnvelope()
    {
        if (outlineEnvelope != null)
            outlineEnvelope.effectColor = Color.white; // Возвращение к исходному цвету
    }
}
