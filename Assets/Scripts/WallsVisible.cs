using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsVisible : MonoBehaviour
{
    [SerializeField]
    private GameObject _point = null;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            if (collision.transform.position.y < _point.transform.position.y)
            {
                Destroy(transform.gameObject);
            }
        }
    }
}
