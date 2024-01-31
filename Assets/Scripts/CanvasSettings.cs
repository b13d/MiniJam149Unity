using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSettings : MonoBehaviour
{
    [SerializeField]
    Slider _sliderMusic;

    [SerializeField]
    Slider _sliderAudio;

    [SerializeField]
    private AudioSource _audioSourcePlayer;

    GameSettings _gameSettings;
   

    private void Start()
    {
        _gameSettings = GameSettings.instance;

        _sliderMusic.value = _gameSettings.VolumeMusic;
        _sliderAudio.value = _gameSettings.VolumeAudio;
    }

    public void ChangeMusicVolume()
    {
        _gameSettings.VolumeMusic = _sliderMusic.value;
        
        AudioSource m_Music = _gameSettings.AudioSourceMusic;

        m_Music.volume = _sliderMusic.value;
    }

    public void ChangeAudioVolume()
    {
        _gameSettings.VolumeAudio = _sliderAudio.value;

        if (_audioSourcePlayer != null)
        {
            _audioSourcePlayer.volume = _sliderAudio.value;
        }
    }
}
