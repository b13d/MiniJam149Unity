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

    private void Start()
    {
        _sliderMusic.value = GameSettings.instance.VolumeMusic;
        _sliderAudio.value = GameSettings.instance.VolumeAudio;
    }

    public void ChangeMusicVolume()
    {
        GameSettings.instance.VolumeMusic = _sliderMusic.value;
        
        AudioSource m_Music = GameSettings.instance.AudioSourceMusic;

        m_Music.volume = _sliderMusic.value;
    }

    public void ChangeAudioVolume()
    {
        GameSettings.instance.VolumeAudio = _sliderAudio.value;

        if (_audioSourcePlayer != null)
        {
            _audioSourcePlayer.volume = _sliderAudio.value;
        }
    }
}
