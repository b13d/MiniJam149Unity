using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] GameObject _player;

    void LateUpdate()
    {
        if (!_player.GetComponent<PlayerController>().ShakingProperty)
        {
            transform.position = new Vector3(transform.position.x, _player.transform.position.y, -10f);
        }
    }
}
