using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayerControl : MonoBehaviour
{

    private Animator _playerAnimator;

    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }


    public void ChangeAnimationOnIdle()
    {
    }
}
