using System;
using UnityEngine;
using TMPro;
[CreateAssetMenu(fileName = "DialogSo", menuName = "Scriptable Objects/DialogSo")]
public class DialogSo : ScriptableObject
{

    [SerializeField] public string[] dialog;

    [SerializeField] public string currentDialog;

    [SerializeField] public SpriteRenderer sprite;

    public int index = 0;



    public void IncreaseIndex()
    {
        index++;
        currentDialog = dialog[index];
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
