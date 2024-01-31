using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDown : MonoBehaviour
{
    [SerializeField] bool _wasTouchDown = false;
    [SerializeField] float _timeToDown = 2f;
    [SerializeField] GameObject _sprites;


    private void Start()
    {
        _sprites = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (_wasTouchDown)
        {
            _timeToDown -= Time.deltaTime;

            if (_timeToDown > 0)
            {
                _sprites.transform.position += new Vector3(Random.Range(-.01f, .01f), Random.Range(-.01f, .01f), 1);
            } else
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            _wasTouchDown = true;
        }
    }
}
