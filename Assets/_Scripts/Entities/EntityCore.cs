using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCore : MonoBehaviour
{
    [Header("Transforms")]
    public Transform body;
    public Transform feet;

    [Header("Components")]
    public Animator anim;
    public Rigidbody2D rgbd;
    public SpriteRenderer spriteRenderer;
}
