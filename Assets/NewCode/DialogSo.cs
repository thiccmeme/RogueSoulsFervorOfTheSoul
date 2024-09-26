using System;
using UnityEngine;
using TMPro;
[CreateAssetMenu(fileName = "DialogSo", menuName = "Scriptable Objects/DialogSo")]
public class DialogSo : ScriptableObject
{

    [SerializeField] public string[] dialog;

    [SerializeField] public string currentDialog;

    [SerializeField] public SpriteRenderer sprite;
    [SerializeField] public bool dialogFinished;
    [SerializeField]

    public int index = 0;



    public void IncreaseIndex()
    {

        Debug.Log(index);
        if (index <= dialog.Length && dialogFinished != true)
        {
            index++;
            currentDialog = dialog[index];
            if (index == dialog.Length - 1)
            {
                dialogFinished = true;
            }
        }
        /*else
        {
            ResetDialog();
        }*/
    }

    public void ResetDialog()
    {
        index = 0;
        currentDialog = dialog[index];
        dialogFinished = false;
    }

    public void Awake()
    {
        //index = 0;
        //currentDialog = dialog[index];
        //Debug.Log(currentDialog);
    }
}
