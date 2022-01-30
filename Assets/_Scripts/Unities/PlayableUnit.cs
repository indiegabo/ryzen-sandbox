using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableUnit : Unit, IDamageable
{
    public virtual void TakeDamage(float amount, GameObject aggressor, float? knockBackForce)
    {
        this.LoseHP(amount);
    }
}
