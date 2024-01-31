using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour
{
    const int CHANCE = 10;
    const int CHANCE_BUFF = 5;

    [SerializeField]
    private List<GameObject> _platforms = new List<GameObject>();

    [SerializeField]
    private float _lastPosX = 0f;

    [SerializeField]
    private float _currentPosY = 0;

    [SerializeField]
    private GameObject _health;

    [SerializeField]
    private GameObject _buff;

    private void Awake()
    {
        _currentPosY = Random.Range(-5f, -3f);
    }

    void Update()
    {
        if (transform.childCount < 30)
        {
            SpawnPlatform();
        }
    }

    void SpawnPlatform()
    {
        int rnd = Random.Range(0, 100);
        bool spawnHealth = false;
        bool spawnBuff = false;


        if (rnd <= CHANCE)
        {
            spawnHealth = true;
        }

        if (!spawnHealth)
        {
            rnd = Random.Range(0, 100);

            if (CHANCE_BUFF >= rnd)
            {
                spawnBuff = true;
            }
        }

        int rndIndexPlatform = Random.Range(0, _platforms.Count);

        float rndPosX;

        if (rndIndexPlatform == 2 || rndIndexPlatform == _platforms.Count - 1)
        {
            if (_lastPosX > 0)
            {
                rndPosX = Random.Range(-3, 0);
            }
            else
            {
                rndPosX = Random.Range(0, 1.55f);
            }
        }
        else
        {
            if (_lastPosX > 0)
            {
                rndPosX = Random.Range(-3.25f, 0);
            }
            else
            {
                rndPosX = Random.Range(0, 2.65f);
            }
        }

        _lastPosX = rndPosX;

        var newPlatform = Instantiate(_platforms[rndIndexPlatform], new Vector3(rndPosX, _currentPosY, 1), Quaternion.identity, transform);

        if (spawnHealth)
        {
            Vector3 posNewPlatform = newPlatform.transform.position;
            Instantiate(_health, new Vector3(posNewPlatform.x, posNewPlatform.y + .5f, 1), Quaternion.identity, newPlatform.transform);
        }

        if (spawnBuff)
        {
            Vector3 posNewPlatform = newPlatform.transform.position;
            Instantiate(_buff, new Vector3(posNewPlatform.x, posNewPlatform.y + .5f, 1), Quaternion.identity, newPlatform.transform);

        }

        _currentPosY -= Random.Range(1.5f, 2.5f);
    }
}
