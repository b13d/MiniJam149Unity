using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using YG;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] GameObject _camera;
    
    [SerializeField] TextMeshProUGUI _txtVelocity;
    [SerializeField] Transform _startPos;
    [SerializeField] TextMeshProUGUI _txtScore;
    [SerializeField] PostProcessVolume _postProcess;
    ChromaticAberration _chromaticAberration;

    Rigidbody2D _rb;
    int oldRecord;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _postProcess = _camera.GetComponent<PostProcessVolume>();

        _postProcess.profile.TryGetSettings(out _chromaticAberration);
        oldRecord = YandexGame.savesData.record;
    }

    private void Update()
    {
        _txtVelocity.text = _rb.velocity.ToString();
    }

    private void FixedUpdate()
    {
        Score();
        Chromatic();

    }

    void Chromatic()
    {
        if (_rb.velocity.y <= -15f)
        {
            _chromaticAberration.active = true;
        }
        else
        {
            _chromaticAberration.active = false;
        }
    }

    void Score()
    {
        int difference = Mathf.RoundToInt(Mathf.Abs(transform.position.y) - Mathf.Abs(_startPos.position.y));

        if (difference > 0)
        {
            _txtScore.text = difference + " ì";

            if (oldRecord < difference)
            {
                YandexGame.savesData.record = difference;
                YandexGame.SaveProgress();
            }
        }
        else
        {
            _txtScore.text = 0 + " ì";
        }
    }
}
