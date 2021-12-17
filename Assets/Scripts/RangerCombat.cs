using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RangerCombat : MonoBehaviour, IChararacterCombat
{

    [Header("Config")]
    [SerializeField] [Range(0.1f, 1f)] private float _loadingShootTime = 0.6f;

    [Header("Needed Objects")]
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private GameObject _arrowObject;

    // Needed Components
    private ICharacterController _character;

    // Flags
    private float _shootButtonPressedAt = 0;

    private void Awake()
    {
        this._character = GetComponent<ICharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void HandleShooting()
    {
        if (this._shootButtonPressedAt <= 0 || !this._character.engagedOnAttack)
            return;
        // Case minimum shoot button press time is reached... SHOOT
        if (Time.time >= this._loadingShootTime + this._shootButtonPressedAt)
        {
            this.Shoot();
        }
        else
        {
            this.AttackDisengage();
        }
    }

    private void Shoot()
    {
        this._character.ChangeState(RangerState.Shoot.ToString());
        Instantiate(this._arrowObject, this._shootingPoint.position, this._shootingPoint.rotation);
        Invoke("AttackDisengage", 0.1f);
    }

    public void AttackDisengage()
    {
        this._character.engagedOnAttack = false;
        this._shootButtonPressedAt = 0;
    }

    // Events
    public void OnPrimaryAttack(InputAction.CallbackContext value)
    {
        // Pressed 
        if (value.started && this._character.grounded)
        {
            this._character.engagedOnAttack = true;
            this._shootButtonPressedAt = Time.time;
            this._character.ChangeState(RangerState.LoadingShoot.ToString());
        }

        // Released
        if (value.canceled && this._character.grounded)
        {
            this.HandleShooting();
        }
    }
}
