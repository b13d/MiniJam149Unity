using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public void AnimationFinish()
    {
        transform.gameObject.SetActive(false);
    }

}
