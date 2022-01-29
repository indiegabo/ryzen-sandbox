using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyzenCore : EntityCore
{
    [Header("Ryzen Transforms")]
    public Transform shootingPoint;
    public Transform empoweredAffordancePoint;

    [Header("Ryzen Components")]
    public CapsuleCollider2D capsuleCollider;
    public RyzenInputHandler inputHandler;

    [Header("Ryzen Data")]
    public RyzenData data;
    [SerializeField] public bool facingRight = true;
}
