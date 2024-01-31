using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] bool _isRight = false;
    [SerializeField] float distance = 0;
    [SerializeField] Vector2 _posXWalls = new Vector2(-3.5f, 5.64f);

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Столкновение");

            if (_isRight)
            {
                distance = transform.position.x + Mathf.Abs(collision.transform.position.x);

                Debug.Log("Distance: " + distance);

                if (distance > 6.5f)
                {
                    collision.transform.position = new Vector2(_posXWalls[0], collision.transform.position.y);
                    Debug.Log("Телепорт к другой стене");
                }
            } else
            {
                distance = transform.position.x + Mathf.Abs(collision.transform.position.x);

                Debug.Log("Distance: " + distance);

                if (distance > 0.2)
                {
                    collision.transform.position = new Vector2(_posXWalls[1] ,collision.transform.position.y);
                    Debug.Log("Телепорт к другой стене: " + _posXWalls[1]);
                }
            }
        }
    }
}
