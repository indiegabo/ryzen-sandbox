using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ryzen Data", menuName = "Ryzen/Data")]
public class RyzenData : ScriptableObject
{

    [Header("Movement Data")]

    [Header("Movement")]
    [SerializeField] [Range(2f, 20f)] private float _horizontalMovementSpeed = 7f;

    [Header("Jump Data")]
    [Range(1.0f, 10.0f)] public float jumpForce = 7f;
    [Range(0.1f, 1f)] public float ascendingLimit = 0.6f;

    [Header("Dash Data")]
    [Range(2f, 15f)] public float dashSpeed = 3f;
    [Range(0f, 2f)] public float dashDuration = 0.5f;
    [Range(0f, 2f)] public float timeBetweenDashes = 1f;

    [Header("Invulnerability Data")]
    [Range(0.5f, 10f)] public float invulnerabilityTimer;
    [Range(0.1f, 1f)] public float invulnerabilityMiniDuration;
    [Range(0.1f, 5f)] public float invulnerabilityTotalDuration;

    [Header("Animation Data")]
    [Range(0.5f, 1f)] public float hitAnimationTime;

    [Header("Combat")]
    [Range(0.1f, 200f)] public float defaultKnockbackForce;
    [Range(0.1f, 1f)] public float loadingShootTime = 0.45f;
    [Range(0.1f, 2f)] public float empoweringShootMin = 1f;
    [Range(0.1f, 2f)] public float empoweringShootMax = 1.5f;

    // Getters 
    public float horizontalMovementSpeed => this._horizontalMovementSpeed;
}
