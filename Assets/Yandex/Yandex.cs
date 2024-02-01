using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class Yandex : MonoBehaviour
{
    [SerializeField]
    GameObject _recordPanel;

    [SerializeField]
    TextMeshProUGUI _txtRecord;

    [DllImport("__Internal")]
    private static extern void GetRecord();

    [DllImport("__Internal")]
    private static extern void SaveGame(string newRecord);

    [DllImport("__Internal")]
    private static extern void InitGame();

    private void Start()
    {
        Debug.Log("Данила");
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            InitGame();
            _recordPanel.SetActive(true);
            Debug.Log("Game in Browser");
        }
        else
        {
            _recordPanel.SetActive(false);
            Debug.Log("Game in Window");
        }



    }

    public void GetData()
    {
        GetRecord();
    }

    
    public void SetData(string record)
    {
        Debug.Log("INITIAL RECORD: " + record);

        _txtRecord.text = record;

        Save(record);
    }


    public void Save(string newRecord)
    {
        SaveGame(newRecord);
    }
}
