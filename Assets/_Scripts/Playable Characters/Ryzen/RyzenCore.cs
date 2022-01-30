using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyzenCore : EntityCore
{
    [Header("Ground Check")]
    public LayerMask whatIsGround;
    [Range(0.1f, 1f)] public float groundCheckRadius = 0.3f;

    [Header("Ryzen Transforms")]
    public Transform shootingPoint;
    public GameObject empoweredAffordanceObject;
    public Transform empoweredAffordancePoint;

    [Header("Ryzen Components")]
    public CapsuleCollider2D capsuleCollider;
    public RyzenInputHandler inputHandler;

    public bool facingRight = true;

    [Header("Combat Objects")]
    public GameObject arrow;
    public GameObject empoweredArrow;

    [Header("Ryzen Data")]
    public RyzenData data;



    // Debug stuff
    public void OnDrawGizmosSelected()
    {
        if (this.feet == null)
            return;

        Gizmos.DrawWireSphere(this.feet.transform.position, this.groundCheckRadius);
    }
}
