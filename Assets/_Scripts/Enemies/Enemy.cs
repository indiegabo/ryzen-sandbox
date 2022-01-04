using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{

    [Header("Config")]
    [SerializeField] [Range(40f, 10000f)] protected float _totalHP = 100f; // Read HP as Health Points

    [Header("Needed objects")]
    [SerializeField] protected GameObject _body;

    // Non Param needed objects
    protected Transform _player;

    // Needed Components
    protected EnemyMovement _enemyMovement;
    protected EnemyCombat _enemyCombat;
    protected IStateManager _stateManager;
    protected Rigidbody2D _rb;

    // HP Stuff
    protected float _currentHP;

    // Flags
    private bool _dead = false;

    public bool dead => this._dead;

    // Combat feedbacks
    public bool takingHit => this._enemyCombat.takingHit;
    public bool chasingPlayer => this._enemyCombat.chasingPlayer;
    public bool attacking => this._enemyCombat.attacking;

    public bool closeToPlayer => Mathf.Abs(this._player.position.x - this.transform.position.x) <= 1;

    // Movement feedbacks
    public bool facingLeft => this._enemyMovement.facingLeft;

    // Non param neeed objects
    public Transform player => this._player;
    public Rigidbody2D rb => this._rb;

    protected void Awake()
    {
        this._stateManager = GetComponent<IStateManager>();
        this._rb = GetComponent<Rigidbody2D>();
        this._enemyMovement = GetComponent<EnemyMovement>();
        this._enemyCombat = GetComponent<EnemyCombat>();
        this._player = FindObjectOfType<PlayableCharacter>().transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        this._currentHP = this._totalHP;
    }

    // Update is called once per frame
    protected void Update()
    {
    }

    protected void FixedUpdate()
    {
    }

    // Actions
    protected void Die()
    {
        GetComponent<Collider2D>().enabled = false;
        this._dead = true;
        this.ChangeState("Die");
        StartCoroutine(this.FadeAndDestroy());
    }

    public void ChangeState(string stateName)
    {
        this._stateManager.ChangeState(stateName);
    }

    public void TakeDamage(float amount)
    {
        this._currentHP -= amount;
        if (this._currentHP <= 0)
        {
            // Die
            this.Die();
        }
        else
        {
            // Take hit
            this._enemyCombat.TakeHit();
        }
    }

    // Checks

    protected IEnumerator FadeAndDestroy()
    {
        yield return new WaitForSeconds(5f);
        SpriteRenderer spriteRenderer = this._body.GetComponent<SpriteRenderer>();
        Color c = spriteRenderer.color;

        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            spriteRenderer.color = c;
            yield return new WaitForSeconds(.1f);
        }

        Destroy(this.gameObject);
    }
}
