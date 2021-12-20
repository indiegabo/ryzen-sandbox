
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
    private PlayableCharacter _character;
    private CanvasController _canvasController;

    // Flags
    private float _engagedAt = 0;
    private bool _attemptingToEngage = false;

    // Objects to be used
    private GameObject _currentEmpoweringAffordance;

    private void Awake()
    {
        this._character = GetComponent<PlayableCharacter>();
        this._canvasController = FindObjectOfType<CanvasController>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.HandleEngagement();
        this.HandleEmpoweringScaling();
    }

    private void FixedUpdate()
    {
    }

    // Handling Stuff
    private void HandleEngagement()
    {
        if (this.CanEngage())
        {
            this.Engage();
        }
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
        this._engagedOnAttack = true;
        this._engagedAt = Time.time;
        this._character.ChangeState(RyzenState.LoadingShoot.ToString());
        this._currentEmpoweringAffordance = Instantiate(this._empoweringAffordanceObject, this._empoweringAffordancePoint.position, this._empoweringAffordancePoint.rotation);
        this._canvasController.ActivateLoadingShootSlider(true);
    }

    public override void Disengage()
    {
        this._engagedOnAttack = false;
        this._attemptingToEngage = false;
        this._engagedAt = 0;
        Destroy(this._currentEmpoweringAffordance);
        this._currentEmpoweringAffordance = null;
        this._canvasController.ActivateLoadingShootSlider(false);
    }

    // Checks
    private bool CanShoot()
    {
        return this._engagedAt > 0 && this._engagedOnAttack;
    }

    private bool CanEngage()
    {
        return !this._engagedOnAttack && this._character._characterMovement.grounded && !this._character._characterMovement.dashing && this._attemptingToEngage;
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
        if (value.canceled && this._character._characterMovement.grounded)
        {
            this._attemptingToEngage = false;
            this.HandleShooting();
        }
    }
}
