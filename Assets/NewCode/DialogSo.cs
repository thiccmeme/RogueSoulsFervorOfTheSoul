using System;
using UnityEngine;
using TMPro;
[CreateAssetMenu(fileName = "DialogSo", menuName = "Scriptable Objects/DialogSo")]
public class DialogSo : ScriptableObject
{

    [SerializeField] public string[] dialog;

    [SerializeField] public string currentDialog;

    [SerializeField] public SpriteRenderer sprite;
    [SerializeField] public bool DialogFinished = false;

    public int index = 0;



    public void IncreaseIndex()
    {
        if (index < dialog.Length)
        {
            index++;
            currentDialog = dialog[index];
        }
    }

    public void resetDialog()
    {
        index = 0;
        currentDialog = dialog[index];
    }

    public void Awake()
    {
        index = 0;
        currentDialog = dialog[index];
        Debug.Log(currentDialog);
    }
}
