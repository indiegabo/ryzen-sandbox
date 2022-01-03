using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] [Range(1f, 50f)] protected float _defaultSpeed = 2f;
    [SerializeField] protected bool _facingLeft = false;

    protected Enemy _enemy;

    public bool facingLeft => this._facingLeft;

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
        this.FaceEnemy();
    }

    protected void FixedUpdate()
    {
        this.HandleWalk();
    }

    // Handling Stuff
    protected void HandleWalk()
    {
        // If Enemy is dead force stop moving
        if (this._enemy.dead)
        {
            this._enemy.rb.velocity = new Vector2(0, 0);
            return;
        }

        if (this.CanWalk() && this._enemy.chasingPlayer)
        {
            float distanceSign = Mathf.Sign(this._enemy.player.position.x - this.transform.position.x);
            this._enemy.rb.velocity = (Vector2.right * this._defaultSpeed) * distanceSign;
            this._enemy.ChangeState("Walk");
        }
        else
        {
            this._enemy.rb.velocity = new Vector2(0, 0);
            if (!this._enemy.attacking && !this._enemy.takingHit)
            {
                this._enemy.ChangeState("Idle");
            }
        }
    }

    protected void FaceEnemy()
    {
        if (this._enemy.rb.velocity.x > 0 && this._facingLeft || this._enemy.rb.velocity.x < 0 && !this._facingLeft)
        {
            this._facingLeft = !this._facingLeft;
            transform.Rotate(0f, -180f, 0f);
        }
    }

    // Checks
    protected bool CanWalk()
    {
        return !this._enemy.takingHit && !this._enemy.dead && !this._enemy.attacking;
    }

}
