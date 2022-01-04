using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{

    [Header("Eye Sight")]
    [SerializeField] [Range(0.5f, 20f)] protected float _eyeSightRange = 5f;

    [Header("Attack")]
    [SerializeField] [Range(0.5f, 5f)] protected float _attackRange = 1f;
    [SerializeField] [Range(2f, 5f)] protected float _attackDelay = 2.5f;
    [SerializeField] [Range(0.1f, 5f)] protected float _attackRadius = 2.5f;
    [SerializeField] [Range(5f, 500f)] protected float _attackDamage = 20f;

    [Header("Needed objects")]
    [SerializeField] protected LayerMask _sightableLayers;
    [SerializeField] protected Transform _eyeSight;
    [SerializeField] protected Transform _attackPosition;
    [SerializeField] protected LayerMask _attackables;

    protected Enemy _enemy;

    protected bool _takingHit = false;
    protected bool _chasingPlayer = false;
    protected bool _attacking = false;

    public bool takingHit => this._takingHit;
    public bool chasingPlayer => this._chasingPlayer;
    public bool attacking => this._attacking;

    // Combat Logic
    protected float _lastAttackedAt = 0;

    protected void Awake()
    {
        this._enemy = GetComponent<Enemy>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.HandlePlayerChase();
    }

    protected void FixedUpdate()
    {
        this.HandleAttack();
    }

    // Handling Stuff
    protected void HandlePlayerChase()
    {
        if (this._enemy.dead)
            return;

        Vector2 endPos = this.CalculateSigthEndPosition();

        RaycastHit2D hit = Physics2D.Linecast(this._eyeSight.position, endPos, this._sightableLayers);

        if (hit.collider != null)
        {
            // if (hit.collider.gameObject.CompareTag("Platform"))
            // {
            //     this._chasingPlayer = false;
            // }

            if (hit.collider.gameObject.CompareTag("Playable"))
            {
                this._chasingPlayer = true;
            }
            else
            {
                this._chasingPlayer = false;
            }
        }
        else
        {
            this._chasingPlayer = false;
        }
    }

    protected void HandleAttack()
    {
        if (this._enemy.dead)
            return;

        if (this.chasingPlayer && Time.time >= this._lastAttackedAt + this._attackDelay)
        {
            float distance = Mathf.Abs(this.transform.position.x - this._enemy.player.transform.position.x);
            if (distance <= this._attackRange)
            {
                // attack
                this._lastAttackedAt = Time.time;
                this._attacking = true;
                this._enemy.ChangeState("Attack");
                Invoke("AttackDone", 1.444f);
            }
        }
    }

    // Actions

    // Called based on EnemyAttackBehaviour
    public void ExecuteAttack()
    {
        Collider2D attackableCollider = Physics2D.OverlapCircle(this._attackPosition.transform.position, this._attackRadius, this._attackables);
        if (attackableCollider == null)
            return;

        if (attackableCollider.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(this._attackDamage);
        }
    }

    public void TakeHit()
    {
        this._takingHit = true;
        if (!this._attacking)
        {
            this._enemy.ChangeState("Hit");
        }
        Invoke("DoneTakingHit", 0.625f);
    }


    protected void DoneTakingHit()
    {
        this._takingHit = false;
    }


    // Checks   

    protected Vector2 CalculateSigthEndPosition()
    {
        Vector2 endPos;

        if (this._enemy.facingLeft)
        {
            endPos = this._eyeSight.position + Vector3.left * this._eyeSightRange;
        }
        else
        {
            endPos = this._eyeSight.position + Vector3.right * this._eyeSightRange;

        }

        return endPos;
    }

    protected void AttackDone()
    {
        this._attacking = false;
    }

    // Debug stuff
    public void OnDrawGizmosSelected()
    {
        if (this._eyeSight == null)
            return;

        // Draw EyeSight
        Vector2 endPos = this._eyeSight.position + Vector3.left * this._eyeSightRange;
        Gizmos.DrawLine(this._eyeSight.position, endPos);

        if (this._attackPosition == null)
            return;

        // Draw Attack Range
        Gizmos.DrawWireSphere(this._attackPosition.transform.position, this._attackRadius);
    }
}
