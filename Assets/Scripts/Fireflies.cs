using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireflies : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("������� ������: " + collision.transform.position);
            Debug.Log("������� ����������: " + transform.position);

            if (collision.transform.position.y < transform.position.y - 5f)
            {
                Destroy(gameObject);
            }
        }
    }
}
