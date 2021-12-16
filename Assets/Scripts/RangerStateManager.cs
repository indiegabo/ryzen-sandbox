using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerStateManager : MonoBehaviour, ICharacterState
{

    [Header("Config")]
    [SerializeField] private string _characterName = "";

    private Animator _animator;

    private string _currentStateName;

    private void Awake()
    {
        this._animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.ChangeState(RangerState.Idle.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeState(string newStateName)
    {
        if (this._currentStateName == newStateName)
            return;

        string animationStateName = this._characterName + "_" + newStateName;
        this._animator.Play(animationStateName);

        this._currentStateName = newStateName;
    }

    public float CurrentAnimationDuration()
    {
        return this._animator.GetCurrentAnimatorStateInfo(0).length;
    }
}
