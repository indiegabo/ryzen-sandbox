using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        this._animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        PlayableCharacterEventManager.OnPLayableCharacterJumped += PlayableCharacterJumped;
        PlayableCharacterEventManager.OnPlayableCharacterDashed += PlayableCharacterDashed;
    }

    private void OnDisable()
    {
        PlayableCharacterEventManager.OnPLayableCharacterJumped -= PlayableCharacterJumped;
        PlayableCharacterEventManager.OnPlayableCharacterDashed -= PlayableCharacterDashed;
    }

    public void PlayableCharacterJumped(GameObject jumpingChararacter)
    {
        this._animator.SetTrigger("_blink_red");
    }

    public void PlayableCharacterDashed(GameObject dashingChararacter)
    {
        Debug.Log("Blinkou Blue");
        this._animator.SetTrigger("_blink_blue");
    }
}
