﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedJoystick : Joystick
{
    private Rigidbody2D _rbPlayer;
    float _speed;

    void CheckPlayer()
    {
        _rbPlayer = PlayerController.GetComponent<Rigidbody2D>();
        _speed = PlayerController.GetSpeedPlayer;
    }

    void Move()
    {
        if (Horizontal < 0)
        {
            if (_rbPlayer.velocity.x < -_speed)
            {
                return;
            }

            _rbPlayer.velocity -= new Vector2(_speed, 0) * Time.deltaTime;
        }
        else if (Horizontal > 0)
        {
            if (_rbPlayer.velocity.x > _speed)
            {
                return;
            }

            _rbPlayer.velocity += new Vector2(_speed, 0) * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (_rbPlayer == null)
        {
            CheckPlayer();
        } else
        {
            Move();
        }

       
    }
}