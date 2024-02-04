using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{
    public static GameSettings instance = null;

    private int record;

    private bool isPaused = false;

    [SerializeField]
    private AudioSource m_Music;

    [SerializeField]
    private float _volumeAudio = .5f;

    [SerializeField]
    private float _volumeMusic = .5f;

    [SerializeField]
    private GameObject _canvasSettings = null;

    [SerializeField]
    private GameObject _canvasMenu = null;

    [SerializeField]
    private GameObject _authPanel = null;

    public int Record
    {
        get { return record; }
        set { if (record < value) record = value; }
    }

    public float VolumeAudio
    {
        get { return _volumeAudio; }
        set
        {
            if (value >= 0 && value <= 1)
            {
                _volumeAudio = value;
            }
        }
    }

    public float VolumeMusic
    {
        get { return _volumeMusic; }
        set
        {
            if (value >= 0 && value <= 1)
            {
                _volumeMusic = value;
            }
        }
    }

    public AudioSource AudioSourceMusic { get { return m_Music; } }

    public bool Paused
    {
        get { return isPaused; }
        set { if (value.GetType() != typeof(bool)) return; isPaused = value; }
    }

    private void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Application.targetFrameRate = 60;
            DontDestroyOnLoad(gameObject);
            instance = this;
        }

        m_Music.volume = VolumeMusic;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Play()
    {
        isPaused = false;
        SceneManager.LoadScene("MainLevel");
        _canvasMenu.SetActive(false);
    }

    public void ShowMenu()
    {
        _canvasMenu.SetActive(true);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Settings()
    {
        _canvasSettings.SetActive(true);
        _canvasMenu.SetActive(false);
    }

    public void CloseSettings()
    {
        _canvasSettings.SetActive(false);
        _canvasMenu.SetActive(true);
    }

    public void ShowAuthPanel()
    {
        _authPanel.SetActive(true);
    }
}
