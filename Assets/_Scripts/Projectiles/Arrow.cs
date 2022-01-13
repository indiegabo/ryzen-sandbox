using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour, IDamager
{
    [Header("Config")]
    [SerializeField] [Range(10f, 40f)] private float _speed = 10f;
    [SerializeField] [Range(10f, 1000f)] private float _damage = 20f;

    private Rigidbody2D _rb;

    private void Awake()
    {
        this._rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        this._rb.velocity = this.transform.right * this._speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IDamageable damageable) && !other.CompareTag(Tag.Playable.ToString()))
        {
            this.ApplyDamage(damageable);
            Destroy(gameObject);
        }
        else if (!other.CompareTag(Tag.Playable.ToString()))
        {
            Destroy(gameObject);
        }
    }

    public void ApplyDamage(IDamageable damageable)
    {
        damageable.TakeDamage(this._damage, gameObject, null);
    }
}
