using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour
{

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Игрок на мне стоит");

        if (collision.collider.tag == "Player")
        {
            var velocityPlayer = collision.collider.gameObject.GetComponent<Rigidbody2D>().velocity;
            if (velocityPlayer.x != 0 || velocityPlayer.y != 0)
            {
                if (velocityPlayer.x != 0)
                {
                    if (velocityPlayer.x < 0)
                    {
                        velocityPlayer.x += Time.deltaTime * 8;
                    }
                    else
                    {
                        velocityPlayer.x -= Time.deltaTime * 8;
                    }
                    
                }

                if (velocityPlayer.y != 0)
                {
                    if (velocityPlayer.y < 0)
                    {
                        velocityPlayer.y += Time.deltaTime * 8;
                    }
                    else
                    {
                        velocityPlayer.y -= Time.deltaTime * 8;
                    }
                }
            }

        }
    }
}
