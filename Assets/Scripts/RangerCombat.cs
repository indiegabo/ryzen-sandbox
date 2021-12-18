using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RangerCombat : MonoBehaviour, IChararacterCombat
{

    [Header("Config")]
    [SerializeField] [Range(0.1f, 1f)] private float _loadingShootTime = 0.45f;
    [SerializeField] [Range(0.5f, 2f)] private float _empoweringShootTime = 1f;

    [Header("Needed Objects")]
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private Transform _empoweringAffordancePoint;
    [SerializeField] private GameObject _arrowObject;
    [SerializeField] private GameObject _empoweredArrowObject;
    [SerializeField] private GameObject _empoweringAffordanceObject;

    // Needed Components
    private ICharacterController _character;

    // Flags
    private float _shootButtonPressedAt = 0;

    // Objects to be used
    private GameObject _currentEmpoweringAffordance;

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
        this.HandleEmpowering();
    }

    private void FixedUpdate()
    {
    }

    private void HandleShooting()
    {
        if (!this.CanShoot())
            return;
        // Case minimum shoot button press time is reached... SHOOT
        if (Time.time >= this._empoweringShootTime + this._loadingShootTime + this._shootButtonPressedAt)
        {
            this.EnpoweredShoot();
        }
        else if (Time.time >= this._loadingShootTime + this._shootButtonPressedAt)
        {
            this.Shoot();
        }
        else
        {
            this.AttackDisengage();
        }
    }

    private void HandleEmpowering()
    {
        if (this._shootButtonPressedAt <= 0 || this._currentEmpoweringAffordance == null)
            return;


        float min = this._shootButtonPressedAt + this._loadingShootTime;
        float max = this._shootButtonPressedAt + this._loadingShootTime + this._empoweringShootTime;

        if (Time.time < min || Time.time > max)
            return;


        float elapsedTime = Time.time - min;

        float scale = Utils.convertScale(elapsedTime, this._empoweringShootTime, 0, 1);

        this._currentEmpoweringAffordance.transform.localScale = new Vector3(scale, scale, 0f);
    }

    private void Shoot()
    {
        this._character.ChangeState(RangerState.Shoot.ToString());
        Instantiate(this._arrowObject, this._shootingPoint.position, this._shootingPoint.rotation);
        Invoke("AttackDisengage", 0.1f);
    }

    private void EnpoweredShoot()
    {
        this._character.ChangeState(RangerState.Shoot.ToString());
        Instantiate(this._empoweredArrowObject, this._shootingPoint.position, this._shootingPoint.rotation);
        Invoke("AttackDisengage", 0.1f);
    }

    public void AttackDisengage()
    {
        this._character.engagedOnAttack = false;
        this._shootButtonPressedAt = 0;
        Destroy(this._currentEmpoweringAffordance);
        this._currentEmpoweringAffordance = null;
    }

    public bool CanShoot()
    {
        return this._shootButtonPressedAt > 0 && this._character.engagedOnAttack;
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
            this._currentEmpoweringAffordance = Instantiate(this._empoweringAffordanceObject, this._empoweringAffordancePoint.position, this._empoweringAffordancePoint.rotation);
        }

        // Released
        if (value.canceled && this._character.grounded)
        {
            this.HandleShooting();
        }
    }
}
