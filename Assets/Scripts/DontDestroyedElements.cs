using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyedElements : MonoBehaviour
{
    public static DontDestroyedElements instance = null;

    private void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

}
