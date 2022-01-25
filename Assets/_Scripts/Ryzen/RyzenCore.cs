using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyzenCore : EntityCore
{
    [Header("Transforms")]
    public Transform shootingPoint;
    public Transform empoweredAffordancePoint;

    [Header("Components")]
    public CapsuleCollider2D capsuleCollider;
    public RyzenInputHandler inputHandler;

    [Header("Data")]
    public RyzenData ryzenData;
}
