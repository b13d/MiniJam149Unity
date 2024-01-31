using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirefliesPlace : MonoBehaviour
{
    [SerializeField]
    GameObject _particleFireflies;

    [SerializeField]
    GameObject _player;

    private void FixedUpdate()
    {
        if (transform.childCount != 3)
        {
            int indexChild = transform.childCount;
            Vector2 newPosition = _player.transform.position - new Vector3(0, 23 * indexChild);
            newPosition.x = 0;
            Instantiate(_particleFireflies, newPosition, Quaternion.identity, transform);
        }
    }
}
