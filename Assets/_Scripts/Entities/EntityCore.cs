using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityCore : MonoBehaviour
{
    [Header("Entity Transforms")]
    [SerializeField] private Transform _body;
    [SerializeField] private Transform _feet;

    [Header("Entity Components")]
    [SerializeField] private Animator _anim;
    [SerializeField] private Rigidbody2D _rgbd;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    // Getters
    public Transform body => this._body;
    public Transform feet => this._feet;
    public Animator anim => this._anim;
    public Rigidbody2D rgbd => this._rgbd;
    public SpriteRenderer spriteRenderer => this._spriteRenderer;
}
