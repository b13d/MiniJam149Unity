using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFon : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;


    void Update()
    {
        transform.position = new Vector3(transform.position.x, _player.transform.position.y, transform.position.z);
    }
}
