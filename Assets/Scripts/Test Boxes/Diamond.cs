using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private enum DiamondState { Idle, Blink }
    private Animator _animator;

    private void Awake()
    {
        this._animator = GetComponent<Animator>();
    }

    private void Start()
    {

    }

    private void OnEnable()
    {
        PlayableCharacterEventManager.OnPlayableCharacterJumpStarted += PlayableCharacterJumpStarted;
    }

    private void OnDisable()
    {
        PlayableCharacterEventManager.OnPlayableCharacterJumpStarted -= PlayableCharacterJumpStarted;
    }

    public void PlayableCharacterJumpStarted(GameObject jumpingChararacter)
    {
        this._animator.SetTrigger("_blink");
    }
}
