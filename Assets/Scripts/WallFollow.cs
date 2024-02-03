using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    void LateUpdate()
    {
        transform.position = new Vector3(0, _player.transform.position.y, transform.position.z);    
    }
}
