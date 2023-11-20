using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highliter : MonoBehaviour
{
    [SerializeField] private int numberTask;
    private Outline outlineTask;
    private void Start()
    {
        outlineTask = GetComponent<Outline>();
        //ChangeInteractable();
    }
    private void Update()
    {
        ChangeInteractable();
    }
    public void OnPointerEnterTask()
    {
        if (outlineTask != null && CheckIsInteractable())
            outlineTask.effectColor = Color.red; // Изменение цвета обводки
    }
    public void OnPointerExitTask()
    {
        if (outlineTask != null && CheckIsInteractable())
            outlineTask.effectColor = Color.white; // Возвращение к исходному цвету
    }
    private bool CheckIsInteractable()
    {
        return GameController.Instance.CheckIsInteractableTask(numberTask);
    }
    private void ChangeInteractable()
    {
        gameObject.GetComponent<Button>().interactable = CheckIsInteractable();
    }
}
