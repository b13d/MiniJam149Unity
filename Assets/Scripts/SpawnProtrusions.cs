using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProtrusions : MonoBehaviour
{
    [SerializeField]
    GameObject _spawnPlace;

    [SerializeField]
    private float _currentY;

    [SerializeField]
    private List<GameObject> _walls = new List<GameObject>();

    [SerializeField]
    private bool _flipY = false;

    [SerializeField]
    private GameObject _lastPosition;

    [SerializeField]
    bool _stopSpawn = false;

    float endWall = 0;

    private void Start()
    {
        _stopSpawn = false;
    }

    void Update()
    {
        if (_spawnPlace.transform.childCount < 24 && !_stopSpawn)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        int indexWall = Random.Range(0, _walls.Count);
        var newWall = _walls[indexWall];

        var sprite = newWall.transform.GetChild(0);

        sprite.GetComponent<SpriteRenderer>().flipY = false;

        if (_flipY)
        {
            sprite.GetComponent<SpriteRenderer>().flipY = true;
        }

        var wall = Instantiate(newWall, _spawnPlace.transform.position + new Vector3(0, endWall, 0), Quaternion.Euler(newWall.transform.eulerAngles), _spawnPlace.transform);

        endWall += sprite.transform.GetChild(1).transform.position.y + 0.015f;

        if (_lastPosition.transform.localPosition.y > wall.transform.localPosition.y)
        {
            Destroy(wall.gameObject);
            _stopSpawn = true;
        }
    }
}
