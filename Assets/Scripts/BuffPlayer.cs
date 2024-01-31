using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuffPlayer : MonoBehaviour
{
    private Vector2 _target = Vector2.zero;

    private bool _activeBuff = false;

    [SerializeField]
    private float _speedMoving = 10f;

    [SerializeField]
    private GameObject _platform;

    Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Buff" && !_activeBuff)
        {
            Destroy(collision.gameObject);

            GetComponent<BoxCollider2D>().isTrigger = true;

            GetComponent<PlayerController>().CanMove = false;

            _target = transform.position;

            _target = new Vector2(_target.x, _target.y - Random.Range(150, 300));

            var newPlatform = _platform;
            newPlatform.transform.GetChild(newPlatform.transform.childCount - 1).gameObject.SetActive(true);

            Debug.Log("newPlatform: " + newPlatform);

            Instantiate(newPlatform, new Vector3(0, _target.y - 0.5f, 1), Quaternion.identity);

            _activeBuff = true;
        }
    }

    private void FixedUpdate()
    {
        if (_activeBuff && !GameSettings.instance.Paused)
        {
            MovingBuff();
        }
    }

    void MovingBuff()
    {
        if (transform.position.x < 0 && transform.position.x < -0.25f)
        {
            transform.position += new Vector3(_speedMoving, 0,0) * Time.deltaTime;
        }

        if (transform.position.x > 0 && transform.position.x > 0.25f)
        {
            transform.position -= new Vector3(_speedMoving, 0, 0) * Time.deltaTime;
        }

        if (_target.y < transform.position.y)
        {
            rb.velocity = new Vector2(0, -24f);
        } else
        {
            GetComponent<PlayerController>().CanMove = true;
            GetComponent<BoxCollider2D>().isTrigger = false;

            rb.velocity = Vector2.zero;

            _activeBuff = false;
        }

    }
}
