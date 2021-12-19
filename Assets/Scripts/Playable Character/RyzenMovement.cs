using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RyzenMovement : PlayableCharacterMovement
{
    [Header("Config")]
    [SerializeField] [Range(1.0f, 10.0f)] private float _runSpeed = 2f;
    [SerializeField] [Range(1.0f, 10.0f)] private float _jumpForce = 2f;
    [SerializeField] [Range(0.1f, 1f)] private float _groundCheckRadius = 0.3f;
    [SerializeField] [Range(0.1f, 1f)] private float _jumpTimeLimit = 0.2f;

    [Header("Needed Objects")]
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private GameObject _playerFeet;

    [Header("Input")]
    [SerializeField] private PlayerInput playerInput;

    // Components
    private Rigidbody2D _rb;
    private PlayableCharacter _character;

    // Configs
    private bool _isJumping;
    private float _jumpTimeCounter = 0f;
    private bool _jumpButtomPressed = false;
    private bool _facingRight = true;

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
    void Update()
    {
        this.HandleGrounding();
        this.HandleJump();
        this.FaceCharacter();
    }


    private void FixedUpdate()
    {
        this.Move();
    }


    // Handling Stuff
    protected override void HandleGrounding()
    {
        this._character.grounded = this.CheckGrounding();

        // Animates Ascending or descending based on Y axis velocity
        if (!this._character.grounded)
        {
            if (Mathf.Sign(this._rb.velocity.y) > 0)
            {
                this._character.ChangeState(RyzenState.Ascending.ToString());
            }
            else
            {
                this._character.ChangeState(RyzenState.Descending.ToString());
            }
        }
    }

    protected override void HandleJump()
    {
        if (this._jumpButtomPressed && this._isJumping)
        {
            this._rb.velocity = new Vector2(this._rb.velocity.x, this._jumpForce);
            this._jumpTimeCounter -= Time.deltaTime;
        }
        else if (!this._jumpButtomPressed && this._isJumping)
        {
            this._isJumping = false;
        }

        if (this._jumpTimeCounter <= 0)
        {
            this._isJumping = false;
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

    // Checks
    private bool CheckGrounding()
    {
        // Checks if the feet object collides with some ground
        return Physics2D.OverlapCircle(this._playerFeet.transform.position, this._groundCheckRadius, this._whatIsGround);
    }

    private bool CanJump()
    {
        return this._character.grounded;
    }

    // Executing Stuff
    protected override void Move()
    {
        if (!this._character.engagedOnAttack)
        {
            this._rb.velocity = new Vector2(this.currentControlThrow.x * this._runSpeed, this._rb.velocity.y);

            // Change States based on being grounded
            if (this._character.grounded)
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
        else
        {
            this._rb.velocity = new Vector2(0, this._rb.velocity.y);
        }
    }


    // Event Callbacks
    public override void OnJump(InputAction.CallbackContext value)
    {
        // If button is pressed
        if (value.started)
        {
            // Starts jump case criteria is met
            if (this.CanJump())
            {
                this._jumpButtomPressed = true;
                this._isJumping = true;
                this._jumpTimeCounter = this._jumpTimeLimit;
                PlayableCharacterEventManager.OnJumpStart(this.gameObject);
            }
        }

        // If button is released
        if (value.canceled)
        {
            this._jumpButtomPressed = false;
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
