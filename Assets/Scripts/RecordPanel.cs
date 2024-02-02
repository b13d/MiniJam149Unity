using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class RecordPanel : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI txtScoreRecord;


    void Start()
    {
        // тут возможно ошибка
        if (Application.platform != RuntimePlatform.WebGLPlayer)
        {
            gameObject.SetActive(false);
        } else
        {
            GetData();
        }
    }

    void GetData()
    {
        txtScoreRecord.text = YandexGame.savesData.record.ToString();
    }
}
