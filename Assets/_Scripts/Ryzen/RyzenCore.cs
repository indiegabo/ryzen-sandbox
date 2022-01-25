using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyzenCore : MonoBehaviour
{
    [Header("Transforms")]
    public Transform body;
    public Transform feet;
    public Transform shootingPoint;
    public Transform empoweredAffordancePoint;

    [Header("Components")]
    public Animator anim;
    public Rigidbody2D rgbd;
    public SpriteRenderer spriteRenderer;
    public CapsuleCollider2D capsuleCollider;
    public RyzenInputHandler inputHandler;

    [Header("Data")]
    public RyzenData ryzenData;
}
