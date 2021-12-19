using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private enum DiamondState { Idle, Blink }
    private DiamondStateManager _diamondStateManager;

    private void Awake()
    {
        this._diamondStateManager = GetComponent<DiamondStateManager>();
    }

    private void Start()
    {
        this._diamondStateManager.ChangeState(DiamondState.Idle.ToString());
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
        bool changedState = this._diamondStateManager.ChangeState(DiamondState.Blink.ToString());
        if (changedState)
            StartCoroutine(this.Blink());
    }
    IEnumerator Blink()
    {
        yield return new WaitForSeconds(this._diamondStateManager.blinkAnimationTime);
        this._diamondStateManager.ChangeState(DiamondState.Idle.ToString());
    }
}
