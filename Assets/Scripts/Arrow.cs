using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [Header("Config")]
    [SerializeField][Range(1f, 20f)] private float _speed = 2f;

    private Character _character;
    private Rigidbody2D _rb;

    private void Awake() {
        this._rb = GetComponent<Rigidbody2D>();        
    }

    // Start is called before the first frame update
    void Start()
    {
        this._rb.velocity = this.transform.right * this._speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
    }
}
