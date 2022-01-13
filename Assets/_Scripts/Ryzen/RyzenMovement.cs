using UnityEngine;

public class RyzenMovement : PlayableCharacterMovement
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.HandleOnAirState();
        this.HandleHorizontalMovementState();
    }


    // Handling Stuff
    protected override void HandleOnAirState()
    {
        if (this._playableCharacter.isDead || this._playableCharacter.takingHit)
            return;

        // Animates Ascending or descending based on Y axis velocity
        if (!this._grounded)
        {
            if (Mathf.Sign(this._rb.velocity.y) > 0) // Case Ryzen is ascending
            {
                this._playableCharacter.ChangeState(RyzenState.Ascending.ToString());
            }
            else if (!this._dashing) // Case Ryzen is descending and not dash animated
            {
                this._playableCharacter.ChangeState(RyzenState.Descending.ToString());
            }
        }
    }

    protected override void HandleHorizontalMovementState()
    {
        if (this._playableCharacter.isDead || this._playableCharacter.takingHit) // Can't move if dead or during hit animation
            return;

        // Change States based on being grounded
        if (this._grounded && !this._playableCharacter.engagedOnAttack && !this._dashing)
        {
            if (Mathf.Abs(this._rb.velocity.x) > 0) // If moving on any x direction 
            {
                this._playableCharacter.ChangeState(RyzenState.Running.ToString());
            }
            else if (Mathf.Abs(this._rb.velocity.x) == 0) // Ryzen has 0 horizontal movement
            {
                this._playableCharacter.ChangeState(RyzenState.Idle.ToString());
            }
        }
        else if (this._grounded && !this._playableCharacter.engagedOnAttack && this._dashing) // Can't animate dash if engaged on attack
        {
            this._playableCharacter.ChangeState(RyzenState.Dashing.ToString());
        }
    }
}
