using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RangerCombat : MonoBehaviour, IChararacterCombat
{
    private const float MIN_EMPOWERING_SCALE = 0f;
    private const float MAX_EMPOWERING_SCALE = 1f;

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
    private CanvasController _canvasController;

    // Flags
    private float _shootButtonPressedAt = 0;

    // Objects to be used
    private GameObject _currentEmpoweringAffordance;

    private void Awake()
    {
        this._character = GetComponent<ICharacterController>();
        this._canvasController = FindObjectOfType<CanvasController>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.HandleEmpoweringScaling();
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

    private void HandleEmpoweringScaling()
    {
        if (this._shootButtonPressedAt <= 0 || this._currentEmpoweringAffordance == null)
            return;


        float min = this._shootButtonPressedAt + this._loadingShootTime;
        float max = this._shootButtonPressedAt + this._loadingShootTime + this._empoweringShootTime;

        if (Time.time < min || Time.time > max)
            return;

        float elapsedTime = Time.time - min;
        float scale = Utils.convertScale(elapsedTime, this._empoweringShootTime, MIN_EMPOWERING_SCALE, MAX_EMPOWERING_SCALE, 0.95f);
        this._currentEmpoweringAffordance.transform.localScale = new Vector3(scale, scale, 1f);
        this._canvasController.SetLoadingShootSlider(scale);
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
        this._canvasController.ActivateLoadingShootSlider(false);
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
            this._canvasController.ActivateLoadingShootSlider(true);
        }

        // Released
        if (value.canceled && this._character.grounded)
        {
            this.HandleShooting();
        }
    }
}
