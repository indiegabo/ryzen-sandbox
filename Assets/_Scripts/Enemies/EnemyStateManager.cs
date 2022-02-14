using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private string _enemyName = "";

    private Animator _animator;

    private string _currentStateName;

    private void Awake()
    {
        this._animator = GetComponent<Animator>();
    }

    public bool ChangeState(string newStateName)
    {
        if (this._currentStateName == newStateName)
            return false;

        string animationStateName = this._enemyName + "_" + newStateName;
        this._animator.Play(animationStateName);
        this._currentStateName = newStateName;
        return true;
    }

    public float CurrentAnimationDuration()
    {
        return this._animator.GetCurrentAnimatorStateInfo(0).length;
    }
}
