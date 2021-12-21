
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayableCharacterMovement : MonoBehaviour
{

    [Header("Needed Objects")]
    [SerializeField] protected LayerMask _whatIsGround;
    [SerializeField] protected GameObject _playerFeet;

    [Header("Grounding")]
    [SerializeField] [Range(0.1f, 1f)] protected float _groundCheckRadius = 0.3f;

    [Header("Running")]
    [SerializeField] [Range(1.0f, 10.0f)] protected float _runSpeed = 2f;

    [Header("Jumping")]
    [SerializeField] [Range(1.0f, 10.0f)] protected float _jumpForce = 2f;
    [SerializeField] [Range(0.1f, 1f)] protected float _jumpTimeLimit = 0.2f;

    [Header("Dashing")]
    [SerializeField] [Range(2f, 6f)] protected float _dashSpeed = 3f;
    [SerializeField] [Range(0f, 2f)] protected float _dashDuration = 0.5f;
    [SerializeField] [Range(0f, 2f)] protected float _timeBetweenDashes = 1f;

    // Components
    protected Rigidbody2D _rb;
    protected PlayableCharacter _character;


    // Configs
    protected float _jumpTimeCounter = 0f;
    protected bool _jumpButtomPressed = false;
    protected bool _facingRight = true;
    protected float _currentDashTimeRemaining = 0f;
    protected float _canDashAgainTime = 0f;

    // Flags
    protected bool _grounded;
    protected bool _dashing;
    protected bool _jumping;

    public bool grounded => _grounded;
    public bool dashing => _dashing;
    public bool jumping => _jumping;

    // Handling stuff    
    protected Vector2 currentControlThrow = new Vector2(0, 0);

    // MonoBehaviour Cycle
    protected virtual void Awake()
    {
        this._rb = GetComponent<Rigidbody2D>();
        this._character = GetComponent<PlayableCharacter>();
    }

    protected virtual void Update()
    {
        this.HandleGrounding();
        this.HandleJump();
        this.FaceCharacter();
    }

    protected virtual void FixedUpdate()
    {
        this.Move();
        this.Dash();
    }

    // Handling Stuff
    protected virtual void HandleGrounding()
    {
        this._grounded = Physics2D.OverlapCircle(this._playerFeet.transform.position, this._groundCheckRadius, this._whatIsGround);
    }

    protected virtual void HandleJump()
    {
        if (this._jumpButtomPressed && this._jumping)
        {
            this._rb.velocity = new Vector2(this._rb.velocity.x, this._jumpForce);
            this._jumpTimeCounter -= Time.deltaTime;
        }
        else if (!this._jumpButtomPressed && this._jumping)
        {
            this._jumping = false;
        }

        if (this._jumpTimeCounter <= 0)
        {
            this._jumping = false;
        }
    }


    // Executing stuff
    protected virtual void Move()
    {
        if (!this._character.isEngagedOnAttack() && !this._dashing)
        {
            this._rb.velocity = new Vector2(this.currentControlThrow.x * this._runSpeed, this._rb.velocity.y);
        }
        else if (!this._dashing)
        {
            this._rb.velocity = new Vector2(0, this._rb.velocity.y);
        }
    }

    protected virtual void Dash()
    {
        if (this._currentDashTimeRemaining > 0 && this._dashing)
        {
            this._currentDashTimeRemaining -= Time.deltaTime;
            if (this._facingRight)
            {
                this._rb.velocity = new Vector2(this._dashSpeed, this.transform.position.y);
            }
            else
            {
                this._rb.velocity = new Vector2(-this._dashSpeed, this.transform.position.y);
            }
        }
        else if (this._dashing)
        {
            this._dashing = false;
        }
    }
    protected virtual void FaceCharacter()
    {
        if (this._rb.velocity.x < 0 && this._facingRight || this._rb.velocity.x > 0 && !this._facingRight)
        {
            this._facingRight = !this._facingRight;
            transform.Rotate(0f, -180f, 0f);
        }
    }

    // Checks
    protected bool CanJump()
    {
        return this._grounded;
    }
    protected bool CanDash()
    {
        return this._grounded && Time.time >= this._canDashAgainTime;
    }

    // Event Callbacks
    public virtual void OnJumpAction(InputAction.CallbackContext action)
    {
        // If button is pressed
        if (action.started)
        {
            // Starts jump case criteria is met
            if (this.CanJump())
            {
                this._jumpButtomPressed = true;
                this._jumpTimeCounter = this._jumpTimeLimit;
                this._jumping = true;
                this._character.OnJumpStart();
                PlayableCharacterEventManager.OnPLayableCharacterJumpStart(this.gameObject);
            }
        }

        // If button is released
        if (action.canceled)
        {
            this._jumpButtomPressed = false;
        }

    }

    public virtual void OnDashAction(InputAction.CallbackContext action)
    {
        // If button is pressed
        if (action.started)
        {
            // Starts dashing case criteria is met
            if (this.CanDash())
            {
                this._dashing = true;
                this._currentDashTimeRemaining = this._dashDuration;
                this._canDashAgainTime = Time.time + this._timeBetweenDashes;
                this._character.OnDashStart();
            }
        }

    }

    public virtual void OnMovement(InputAction.CallbackContext value)
    {
        this.currentControlThrow = value.ReadValue<Vector2>();
    }

    public virtual void OnStickMovement(InputAction.CallbackContext value)
    {
        this.currentControlThrow = value.ReadValue<Vector2>();
    }

    protected abstract void HandleOnAirState();
    protected abstract void HandleHorizontalMovementState();


    // Debug stuff
    public void OnDrawGizmosSelected()
    {
        if (this._playerFeet == null)
            return;

        Gizmos.DrawWireSphere(this._playerFeet.transform.position, this._groundCheckRadius);
    }
}
