using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour, IDamager
{
    [Header("Config")]
    [SerializeField] [Range(10f, 40f)] private float _speed = 10f;
    [SerializeField] [Range(10f, 1000f)] private float _damage = 20f;

    // Needed Objects
    [SerializeField] private GameObject _empoweredParticleSystem;

    // Logic Stuff
    private GameObject _currentEmpoweredParticleSystem;

    private Rigidbody2D _rb;

    private void Awake()
    {
        this._rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        this._rb.velocity = this.transform.right * this._speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IDamageable damageable) && !other.CompareTag(Tag.Playable.ToString()))
        {
            this.ApplyDamage(damageable);
            this.DestroyArrow();
        }
        else if (!other.CompareTag(Tag.Playable.ToString()))
        {
            this.DestroyArrow();
        }
    }

    public void ApplyDamage(IDamageable damageable)
    {
        damageable.TakeDamage(this._damage, gameObject, null);
    }

    private void DestroyArrow()
    {
        if (this._empoweredParticleSystem != null)
        {
            this._empoweredParticleSystem.transform.parent = gameObject.transform.parent;
        }

        Destroy(gameObject, 0.1f);
    }
}
