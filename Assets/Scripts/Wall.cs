using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]
    private bool isRight;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Rigidbody2D _rbPlayer;
            _rbPlayer = collision.GetComponent<Rigidbody2D>();

            Vector3 posPlayer = collision.transform.position;
            float posPlayerX;

            if (posPlayer.x < 0)
            {
                posPlayerX = posPlayer.x + 1;
            } else
            {
                posPlayerX = posPlayer.x - 1;
            }

            collision.transform.position = new Vector3(posPlayerX * -1, posPlayer.y, posPlayer.z);
        }
    }
}
