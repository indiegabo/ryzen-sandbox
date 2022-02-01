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
        RyzenEventManager.OnRyzenJumped += RyzenJumped;
        RyzenEventManager.OnRyzenDashed += RyzenDashed;
    }

    private void OnDisable()
    {
        RyzenEventManager.OnRyzenJumped -= RyzenJumped;
        RyzenEventManager.OnRyzenDashed -= RyzenDashed;
    }

    public void RyzenJumped(GameObject jumpingChararacter)
    {
        this._animator.SetTrigger("_blink_red");
    }

    public void RyzenDashed(GameObject dashingChararacter)
    {
        this._animator.SetTrigger("_blink_blue");
    }
}
