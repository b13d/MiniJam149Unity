using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagmentCanvas : MonoBehaviour
{
    [SerializeField]
    GameObject _canvasSettings;

    public void OpenSettings()
    {
        _canvasSettings.SetActive(true);
        GameSettings.instance.Paused = true;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        GameSettings.instance.ShowMenu();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameSettings.instance.Paused = false;
    }

    public void CloseSettings()
    {
        _canvasSettings.SetActive(false);
        GameSettings.instance.Paused = false;
    }
}
