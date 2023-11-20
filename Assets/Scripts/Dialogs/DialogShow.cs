using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogShow : DialogsDictionary
{
    [SerializeField] private Image imageCharacter;
    [SerializeField] private Image imageYou;
    [SerializeField] private TextMeshProUGUI nameCharacter;
    [SerializeField] private TextMeshProUGUI textDialog;

    private string _text;
    private int _dialogIdStart ;
    private int _dialogIdFinish ;
    [SerializeField] private GameObject panelDialog;
    [SerializeField] private GameObject buttonGoFinish;
    [SerializeField] private GameObject buttonSkip;
    public static DialogShow Instance
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
    static private DialogShow _instance;

    public void GetDialog(int start, int end) 
    {
        _dialogIdStart = start;
        _dialogIdFinish = end;
        GenerateDialog();
        CheckButtonFinish();
    }
    private void CheckButtonFinish()
    {
        Debug.Log(_dialogIdFinish + " " + dicDialogs.Count);
        if(_dialogIdFinish + 1 == dicDialogs.Count)
        {
            buttonGoFinish.SetActive(true);
            buttonSkip.SetActive(false);
        }
    }
    public Dialogs GetDialog(int dialogId)
    {
        if (dicDialogs.ContainsKey(dialogId))
        {
            return dicDialogs[dialogId];
        }
        else
        {
            return null;
        }
    }
    private void GenerateDialog()
    {
        Dialogs dialog = GetDialog(_dialogIdStart);
        if (dialog != null)
        {
            nameCharacter.text = dialog.NameCharacter;
            _text = dialog.Text;
            StartCoroutine(WriteText());
        }
    }

    IEnumerator WriteText()
    {
        for (int i = 0; i < _text.Length; i++)
        {
            textDialog.text = _text.Substring(0, i);
            yield return new WaitForSeconds(.05f);
        }

        if (_dialogIdStart != _dialogIdFinish)
        {
            UpdateDialogId();
            GenerateDialog(); // Генерация следующего диалога
        }
    }

    private void UpdateDialogId()
    {
        if (_dialogIdStart < _dialogIdFinish)
        {
            _dialogIdStart++;
        }
    }

    public void SkipDialog()
    {
        panelDialog.SetActive(false);
        /*StopAllCoroutines();
        textDialog.text = _text;
        if (_dialogIdStart != _dialogIdFinish)
        {
            UpdateDialogId();
            GenerateDialog(); // Генерация следующего диалога
        }*/
    }
    public void GoFinish()
    {
        GameController.Instance.OpenImageHall();
    }
    
}
