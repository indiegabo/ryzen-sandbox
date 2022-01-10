using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableUnit : Unit, IDamageable
{
    public void TakeDamage(float amount, float? knockBackForce)
    {
        this.LoseHP(amount);

        if (this.dead)
        {
            Debug.Log("Playable unit has died");
        }
    }
}
