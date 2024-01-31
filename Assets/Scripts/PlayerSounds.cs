using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Sounds: int
{
    damage = 0,
    down,
    jump
}

public class PlayerSounds : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSourcePlayer;

    [SerializeField]
    List<AudioClip> _sounds = new List<AudioClip>();
    
    public AudioClip AudioDamage { get {return _sounds[(int)Sounds.damage]; } }
    public AudioClip AudioDown { get {return _sounds[(int)Sounds.down]; } }
    public AudioClip AudioJump { get {return _sounds[(int)Sounds.jump]; } }


    private void Start()
    {
        _audioSourcePlayer.volume = GameSettings.instance.VolumeAudio;
    }
}
