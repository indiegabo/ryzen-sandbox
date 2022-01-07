using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableUnit : Unit, IDamageable
{
    public void TakeDamage(float amount)
    {
        this.LoseHP(amount);
        Debug.Log("Current HP: " + this._currentHP);
        if (this.dead)
        {
            Debug.Log("Playable unit has died");
        }
    }
}
