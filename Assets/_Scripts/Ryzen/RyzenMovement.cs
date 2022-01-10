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
        if (this._character.isDead || this._character.takingHit)
            return;

        // Animates Ascending or descending based on Y axis velocity
        if (!this._grounded)
        {
            if (Mathf.Sign(this._rb.velocity.y) > 0)
            {
                this._character.ChangeState(RyzenState.Ascending.ToString());
            }
            else if (!this._dashing)
            {
                this._character.ChangeState(RyzenState.Descending.ToString());
            }
        }
    }

    protected override void HandleHorizontalMovementState()
    {
        if (this._character.isDead || this._character.takingHit)
            return;

        // Change States based on being grounded
        if (this._grounded && !this._character.isEngagedOnAttack() && !this._dashing)
        {
            if (Mathf.Abs(this._rb.velocity.x) > 0)
            {
                this._character.ChangeState(RyzenState.Running.ToString());
            }
            else if (Mathf.Abs(this._rb.velocity.x) == 0)
            {
                this._character.ChangeState(RyzenState.Idle.ToString());
            }
        }
        else if (this._grounded && !this._character.isEngagedOnAttack() && this._dashing)
        {
            this._character.ChangeState(RyzenState.Dashing.ToString());
        }
    }
}
