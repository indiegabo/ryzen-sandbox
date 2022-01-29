using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityCore : MonoBehaviour
{
    [Header("Entity Transforms")]
    public Transform body;
    public Transform feet;

    [Header("Entity Components")]
    public Animator anim;
    public Rigidbody2D rgbd;
    public SpriteRenderer spriteRenderer;
}
