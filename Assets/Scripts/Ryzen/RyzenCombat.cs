
using UnityEngine;
using UnityEngine.InputSystem;

public class RyzenCombat : PlayableChararacterCombat
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
    private CanvasController _canvasController;

    // Objects to be used
    private GameObject _currentEmpoweringAffordance;

    // Monobehaviour Cycle
    protected override void Awake()
    {
        base.Awake();
        this._canvasController = FindObjectOfType<CanvasController>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        this.HandleEmpoweringScaling();
    }

    private void HandleShooting()
    {
        if (!this.CanShoot())
        {
            this.Disengage();
            return;
        }

        // Case primary attack button was pressed long enough to power shoot
        if (Time.time >= this._empoweringShootTime + this._loadingShootTime + this._engagedAt)
        {
            this.EmpoweredShoot();
        }
        // Case minimum shoot button press time is reached... SHOOT
        else if (Time.time >= this._loadingShootTime + this._engagedAt)
        {
            this.Shoot();
        }
        else
        {
            this.Disengage();
        }
    }

    private void HandleEmpoweringScaling()
    {
        if (this._engagedAt <= 0 || this._currentEmpoweringAffordance == null)
            return;


        float min = this._engagedAt + this._loadingShootTime;
        float max = this._engagedAt + this._loadingShootTime + this._empoweringShootTime;

        if (Time.time < min || Time.time > max)
            return;

        float elapsedTime = Time.time - min;
        float scale = Calc.convertScale(elapsedTime, this._empoweringShootTime, MIN_EMPOWERING_SCALE, MAX_EMPOWERING_SCALE, 0.95f);
        this._currentEmpoweringAffordance.transform.localScale = new Vector3(scale, scale, 1f);
        this._canvasController.SetLoadingShootSlider(scale);
    }

    // Executing Stuff
    private void Shoot()
    {
        this._character.ChangeState(RyzenState.Shoot.ToString());
        Instantiate(this._arrowObject, this._shootingPoint.position, this._shootingPoint.rotation);
        Invoke("Disengage", 0.1f);
    }

    private void EmpoweredShoot()
    {
        this._character.ChangeState(RyzenState.Shoot.ToString());
        Instantiate(this._empoweredArrowObject, this._shootingPoint.position, this._shootingPoint.rotation);
        Invoke("Disengage", 0.1f);
    }

    protected override void Engage()
    {
        base.Engage();
        this._character.ChangeState(RyzenState.LoadingShoot.ToString());
        this._currentEmpoweringAffordance = Instantiate(this._empoweringAffordanceObject, this._empoweringAffordancePoint.position, this._empoweringAffordancePoint.rotation);
        this._canvasController.ActivateLoadingShootSlider(true);
    }

    protected override void Disengage()
    {
        base.Disengage();
        Destroy(this._currentEmpoweringAffordance);
        this._currentEmpoweringAffordance = null;
        this._canvasController.ActivateLoadingShootSlider(false);
    }

    // Checks
    private bool CanShoot()
    {
        return this._engagedAt > 0 && this._engagedOnAttack;
    }

    // Events
    public override void OnPrimaryAttack(InputAction.CallbackContext value)
    {
        // Primary attack button pressed 
        if (value.started)
        {
            this._attemptingToEngage = true;
        }

        // Primary attack button Released
        if (value.canceled && this._character.isGrounded())
        {
            this._attemptingToEngage = false;
            this.HandleShooting();
        }
    }
}
