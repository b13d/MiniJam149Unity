using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatforms : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Platform") { 
            if (collision.transform.position.y > transform.position.y)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
