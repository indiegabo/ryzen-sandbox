using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ryzen Data", menuName = "Ryzen/Data")]
public class RyzenData : ScriptableObject
{
    [Header("Ground Check Data")]
    public LayerMask whatIsGround;
    [Range(0.1f, 1f)] public float groundCheckRadius;

    [Header("Movement Data")]
    [Range(1.0f, 10.0f)] public float runSpeed;

    [Header("Jump Data")]
    [Range(1.0f, 10.0f)] public float jumpForce;
    [Range(0.1f, 1f)] public float jumpTimeLimit;

    [Header("Dash Data")]
    [Range(2f, 6f)] public float dashSpeed;
    [Range(0f, 2f)] public float dashDuration;
    [Range(0f, 2f)] public float timeBetweenDashes;

    [Header("Invulnerability Data")]
    [Range(0.5f, 10f)] public float invulnerabilityTimer;
    [Range(0.1f, 1f)] public float invulnerabilityMiniDuration;
    [Range(0.1f, 5f)] public float invulnerabilityTotalDuration;

    [Header("Animation Data")]
    [Range(0.5f, 1f)] public float hitAnimationTime;

    [Header("Knockback")]
    [Range(0.1f, 200f)] public float defaultKnockbackForce;
}
