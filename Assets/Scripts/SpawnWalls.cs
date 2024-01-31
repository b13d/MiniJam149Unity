using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWalls : MonoBehaviour
{
    [SerializeField]
    private GameObject _walls;

    [SerializeField]
    private float _currentPos;

    void Update()
    {
        if (transform.childCount < 5)
        {
            Instantiate(_walls, new Vector3(0.0f, _currentPos, 1), Quaternion.identity, transform);

            _currentPos -= 29f;
        }
    }
}
