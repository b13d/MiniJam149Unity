using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class CanvasUI : MonoBehaviour
{
    [SerializeField]
    GameObject _canvasSettings;

    [SerializeField]
    Button _buttonSettings;

    [SerializeField]
    private GameObject _mobilePanel;

    private void Start()
    {
        if (YandexGame.EnvironmentData.isMobile)
        {
            _mobilePanel.SetActive(true);
        } else
        {
            _mobilePanel.SetActive(false);
        }
    }
}
