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

    [SerializeField]
    int maxRecord;

    public int CurrentRecord
    {
        get { return maxRecord; }
        set { maxRecord = value; }
    }


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

    
    public void SetData(string record)
    {
        Debug.Log("INITIAL RECORD: " + record);

        _txtRecord.text = record;

        Save(record);
    }


    public void Save(string newRecord)
    {
        var jsonRecord = JsonUtility.ToJson(newRecord);
        SaveGame(jsonRecord);
    }

    public void Load(string value)
    {
        var newRecord = JsonUtility.FromJson<string>(value);
        _txtRecord.text = newRecord;
    }
}
