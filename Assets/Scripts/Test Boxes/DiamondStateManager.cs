using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondStateManager : MonoBehaviour, IStateManager
{

    [Header("Config")]
    [SerializeField] private string _objectName = "";
    [SerializeField] [Range(0f, 2f)] private float _blinkAnimationTime = 1f;

    private Animator _animator;

    private string _currentStateName;

    public float blinkAnimationTime
    {
        get { return this._blinkAnimationTime; }
    }

    private void Awake()
    {
        this._animator = GetComponent<Animator>();
    }

    public bool ChangeState(string newStateName)
    {
        if (this._currentStateName == newStateName)
            return false;

        string animationStateName = this._objectName + "_" + newStateName;
        this._animator.Play(animationStateName);
        this._currentStateName = newStateName;
        return true;
    }

    public float CurrentAnimationDuration()
    {
        AnimatorStateInfo stateInfo = this._animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.length;
    }
}
