using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RyzenMovement : PlayableCharacterMovement
{
    [Header("Grounding")]
    [SerializeField] [Range(0.1f, 1f)] private float _groundCheckRadius = 0.3f;
    [Header("Running")]
    [SerializeField] [Range(1.0f, 10.0f)] private float _runSpeed = 2f;
    [Header("Jumping")]
    [SerializeField] [Range(1.0f, 10.0f)] private float _jumpForce = 2f;
    [SerializeField] [Range(0.1f, 1f)] private float _jumpTimeLimit = 0.2f;
    [Header("Dashing")]
    [SerializeField] [Range(2f, 6f)] private float _dashSpeed = 3f;
    [SerializeField] [Range(0f, 2f)] private float _dashDuration = 0.5f;
    [SerializeField] [Range(0f, 2f)] private float _timeBetweenDashes = 1f;

    [Header("Needed Objects")]
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private GameObject _playerFeet;

    [Header("Input")]
    [SerializeField] private PlayerInput playerInput;

    // Components
    private Rigidbody2D _rb;
    private PlayableCharacter _character;

    // Configs
    private float _jumpTimeCounter = 0f;
    private bool _jumpButtomPressed = false;
    private bool _facingRight = true;
    private float _currentDashTimeRemaining = 0f;
    private float _canDashAgainTime = 0f;

    private Vector2 currentControlThrow = new Vector2(0, 0);

    private void Awake()
    {
        this._rb = GetComponent<Rigidbody2D>();
        this._character = GetComponent<PlayableCharacter>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update(); // Calling parent's update method
        this.HandleGrounding();
        this.HandleJump();
        this.FaceCharacter();
    }


    private void FixedUpdate()
    {
        this.Move();
        this.Dash();
    }


    // Handling Stuff
    protected override void HandleGrounding()
    {
        this._grounded = Physics2D.OverlapCircle(this._playerFeet.transform.position, this._groundCheckRadius, this._whatIsGround);

        // Animates Ascending or descending based on Y axis velocity
        if (!this._grounded)
        {
            if (Mathf.Sign(this._rb.velocity.y) > 0)
            {
                this._character.ChangeState(RyzenState.Ascending.ToString());
            }
            else if (!this._dashing)
            {
                this._character.ChangeState(RyzenState.Descending.ToString());
            }
        }
    }

    protected override void HandleJump()
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

    protected override void FaceCharacter()
    {
        if (this._rb.velocity.x < 0 && this._facingRight || this._rb.velocity.x > 0 && !this._facingRight)
        {
            this._facingRight = !this._facingRight;
            transform.Rotate(0f, -180f, 0f);
        }
    }

    // Executing Stuff
    protected override void Move()
    {
        if (!this._character.isEngagedOnAttack() && !this._dashing)
        {
            this._rb.velocity = new Vector2(this.currentControlThrow.x * this._runSpeed, this._rb.velocity.y);

            // Change States based on being grounded
            if (this._grounded)
            {
                if (Mathf.Abs(this._rb.velocity.x) > 0)
                {
                    this._character.ChangeState(RyzenState.Running.ToString());
                }
                else if (Mathf.Abs(this._rb.velocity.x) == 0)
                {
                    this._character.ChangeState(RyzenState.Idle.ToString());
                }
            }
        }
        else if (!this._dashing)
        {
            this._rb.velocity = new Vector2(0, this._rb.velocity.y);
        }
    }

    private void Dash()
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

    // Checks
    private bool CanJump()
    {
        return this._grounded;
    }
    private bool CanDash()
    {
        return this._grounded && Time.time >= this._canDashAgainTime;
    }

    // Event Callbacks
    public override void OnJumpAction(InputAction.CallbackContext action)
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

    public override void OnDashAction(InputAction.CallbackContext action)
    {
        // If button is pressed
        if (action.started)
        {
            // Starts dashing case criteria is met
            if (this.CanDash())
            {
                this._dashing = true;
                this._currentDashTimeRemaining = this._dashDuration;
                this._character.ChangeState(RyzenState.Dashing.ToString());
                this._canDashAgainTime = Time.time + this._timeBetweenDashes;
                this._character.OnDashStart();
            }
        }

    }
    public override void OnMovement(InputAction.CallbackContext value)
    {
        this.currentControlThrow = value.ReadValue<Vector2>();
    }

    public override void OnStickMovement(InputAction.CallbackContext value)
    {
        this.currentControlThrow = value.ReadValue<Vector2>();
    }

    // Debug stuff
    public void OnDrawGizmosSelected()
    {
        if (this._playerFeet == null)
            return;

        Gizmos.DrawWireSphere(this._playerFeet.transform.position, this._groundCheckRadius);
    }
}
