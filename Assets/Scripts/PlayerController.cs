using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speedPlayer = 10f;
    [SerializeField] float _touchJumpHold = 0f;
    [SerializeField] bool _touchJump = false;
    [SerializeField] Sprite[] _spritesJump = null;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _directionJump = 1;
    [SerializeField] bool isInvulnerability = false;
    [SerializeField] bool isShaking = false;
    [SerializeField] float _timeInvulnerability = 1f;
    [SerializeField] float _timeShaking = .5f;
    [SerializeField] bool _isJumping = false;

    [SerializeField] GameObject _redPanel;
    [SerializeField] GameObject _healths;
    [SerializeField] int _health = 3;
    [SerializeField] bool _canMove = true;
    bool _wasBuff = false;

    Vector2 startJump = Vector2.zero;
    Vector2 oldVelocity = Vector2.zero;
    float _startPosXCamera = 0f;


    [SerializeField]
    AudioSource _audioSourcePlayer;

    [SerializeField]
    GameObject _canvasLoseWindow;

    PlayerSounds _playerSounds;
    GameObject _sprite;
    Animator _animatorPlayer;

    bool _wasButtonJumpClick;

    [SerializeField]
    UIButtonInfo _buttonJump;

    public bool CanMove
    {
        set { _canMove = value; }
    }

    public bool ShakingProperty
    {
        get { return isShaking; }
    }

    void Start()
    {
        _startPosXCamera = Camera.main.transform.position.x;
        _playerSounds = GetComponent<PlayerSounds>();
        _rb = GetComponent<Rigidbody2D>();
        _sprite = gameObject.transform.GetChild(0).gameObject;
        _animatorPlayer = _sprite.GetComponent<Animator>();

        ResetPlayerSettings();
    }


    void Update()
    {
        if (GameSettings.instance.Paused)
        {
            return;
        }


        if (!_canMove)
        {
            return;
        }

        if (Input.GetKeyUp(KeyCode.Space) && isGrounded() || (WasButtonJumpClick() && isGrounded()))
        {
            _wasButtonJumpClick = false;
            HoldJump();
        }
    }

    bool WasButtonJumpClick()
    {
        return _wasButtonJumpClick && !_buttonJump.isDown;
    }

    void HoldJump()
    {

        if (_touchJumpHold > 4f)
        {
            _touchJumpHold = 4f;
        }

        Vector2 _direction = new Vector2(1.5f * _directionJump, 2f);

        _rb.AddForce(_direction * _touchJumpHold, ForceMode2D.Impulse);

        _sprite.GetComponent<SpriteRenderer>().sprite = _spritesJump[0];

        _touchJump = false;
        _touchJumpHold = 0f;
    }

    public float GetSpeedPlayer
    {
        get { return _speedPlayer; }
    }

    void FixedUpdate()
    {
        Pause();

        if (!_canMove)
        {
            return;
        }

        if (!isGrounded())
        {
            if (_isJumping == false)
            {
                _audioSourcePlayer.PlayOneShot(_playerSounds.AudioJump);

                _touchJumpHold = 0;

                _sprite.GetComponent<SpriteRenderer>().sprite = _spritesJump[0];

                startJump = transform.position;
            }


            _animatorPlayer.SetBool("jump", false);
            _animatorPlayer.SetBool("isFly", true);

            _isJumping = true;
        }
        else
        {
            if (_isJumping == true)
            {
                if (GameSettings.instance.Paused)
                {
                    return;
                }


                _audioSourcePlayer.PlayOneShot(_playerSounds.AudioDown);

                if (!_wasBuff)
                {
                    Debug.Log("startJump.y - 30: " + (startJump.y - 30));
                    Debug.Log("transform.position.y: " + transform.position.y);

                    if (startJump.y - 30 > transform.position.y)
                    {
                        Damage();
                    }
                }
                _wasBuff = false;
            }


            _animatorPlayer.SetBool("isFly", false);
            _isJumping = false;
        }

        if (_isJumping && !isGrounded())
        {
            MoveX();
        }

        if (isShaking)
        {
            _timeShaking -= Time.deltaTime;

            Shaking();

            if (_timeShaking < 0f)
            {
                var posCamera = Camera.main.transform.position;
                Camera.main.transform.position = new Vector3(_startPosXCamera, posCamera.y, posCamera.z);
                isShaking = false;
                _timeShaking = .5f;
            }
        }

        CheckInvulnerability();

        if (_rb.velocity.y < -15f)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, -15);


        }

        RotatePlayer();

        if (isGrounded())
        {
            Jump();
        }
    }


    void Pause()
    {
        if (GameSettings.instance.Paused)
        {
            if (_rb.velocity.x != 0 && _rb.velocity.y != 0)
            {
                oldVelocity = _rb.velocity;
            }

            _rb.gravityScale = 0;

            _rb.velocity = Vector2.zero;

            return;
        }
        else if (oldVelocity != Vector2.zero)
        {
            _rb.velocity = oldVelocity;

            _rb.gravityScale = 1;

            oldVelocity = Vector2.zero;
        }
        else
        {
            _rb.gravityScale = 1;
        }
    }

    public void ResetPlayerSettings()
    {
        _rb.velocity = Vector2.zero;
        _rb.gravityScale = 1;
    }




    void CheckInvulnerability()
    {
        if (isInvulnerability)
        {
            _timeInvulnerability -= Time.deltaTime;

            if (_timeInvulnerability < 0f)
            {
                isInvulnerability = false;
                _timeInvulnerability = 1f;
            }
        }
    }


    void MoveX()
    {
        Debug.Log("Могу лево право");

        if (!_canMove)
        {
            return;
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (_rb.velocity.x < -_speedPlayer)
            {
                return;
            }

            _rb.velocity -= new Vector2(_speedPlayer, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (_rb.velocity.x > _speedPlayer)
            {
                return;
            }

            _rb.velocity += new Vector2(_speedPlayer, 0) * Time.deltaTime;
        }
    }

    public void Jump()
    {
        if (_buttonJump.isDown)
        {
            _wasButtonJumpClick = true;
        }

        if (Input.GetKey(KeyCode.Space) || _buttonJump.isDown)
        {

            _animatorPlayer.SetBool("jump", true);

            _touchJump = true;
        }

        if (_touchJump)
        {
            _touchJumpHold += Time.deltaTime * 4;

            if (_touchJumpHold < 1f)
            {
                _sprite.GetComponent<SpriteRenderer>().sprite = _spritesJump[0];
            }
            else if (_touchJumpHold > 1f && 1.5f > _touchJumpHold)
            {
                _sprite.GetComponent<SpriteRenderer>().sprite = _spritesJump[1];
            }
            else if (_touchJumpHold > 1.5 && 2f > _touchJumpHold)
            {
                _sprite.GetComponent<SpriteRenderer>().sprite = _spritesJump[2];
            }
            else
            {
                _sprite.GetComponent<SpriteRenderer>().sprite = _spritesJump[3];
            }
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _directionJump = 1;
            _sprite.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _directionJump = -1;
            _sprite.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    bool isGrounded()
    {
        if (_rb.velocity.y == 0)
        {
            _rb.velocity = Vector2.zero;
        }

        return _rb.velocity.y == 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameSettings.instance.Paused)
        {
            return;
        }

        if (!_canMove)
        {
            return;
        }

        if (collision.tag == "Spikes")
        {
            if (!isInvulnerability)
            {
                Damage();
            }
        }

        if (collision.tag == "Health")
        {

            Destroy(collision.gameObject);

            for (int i = 0; i < _healths.transform.childCount; i++)
            {
                if (!_healths.transform.GetChild(i).gameObject.active)
                {
                    _healths.transform.GetChild(i).gameObject.SetActive(true);

                    _health += 1;

                    return;
                }
            }
        }

        if (collision.tag == "Buff")
        {
            _wasBuff = true;
        }
    }


    private void Damage()
    {
        _audioSourcePlayer.PlayOneShot(_playerSounds.AudioDamage);

        Debug.Log("Получил урон от шипов");

        isInvulnerability = true;

        _animatorPlayer.SetBool("jump", false);
        _animatorPlayer.SetBool("isFly", false);
        _animatorPlayer.SetTrigger("hit");


        for (int i = _healths.transform.childCount - 1; i >= 0; i--)
        {
            if (_healths.transform.GetChild(i).gameObject.active)
            {
                _healths.transform.GetChild(i).gameObject.SetActive(false);

                _health -= 1;

                isShaking = true;

                _redPanel.SetActive(true);
                _redPanel.GetComponent<Animator>().SetTrigger("Hit");

                if (_health == 0)
                {
                    _canvasLoseWindow.SetActive(true);

                    GameSettings.instance.Paused = true;
                }

                return;
            }
        }
    }

    private void Shaking()
    {
        Camera.main.transform.position = new Vector3(Random.Range(-.2f, .2f), transform.position.y, -10f);
    }
}
