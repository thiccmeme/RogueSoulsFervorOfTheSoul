using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Character Attributes

    [Header("Character Attributes"), Space(5)]

    [SerializeField]
    public float _xSpeed;

    [SerializeField]
    public float _ySpeed;

    [SerializeField]
    float dodgeRollForce;

    [SerializeField]
    float playerFriction;

    [SerializeField]
    float dodgeRollCooldownTime;

    [SerializeField]
    float dodgeRollDurationTime;

    [SerializeField]
    GameObject _playerSpriteObject;

    [SerializeField]
    GameObject _objectCarryPoint;

    [SerializeField]
    float _invulnTime;

    [SerializeField]
    float _grappleHookCancelRadius;

    Animator _animator;

    Vector2 _movementSpeed;

    [SerializeField] Rigidbody2D _rb;

    Vector2 _movement;

    bool _rolling = false;
    bool canRoll = true;

    bool _grappling = false;

    [SerializeField]
    int _bonkDamage;
    [SerializeField]
    int _grappleBonkDamage;

    [SerializeField]
    float _bonkKnockback;

    public bool PreventingInput { get; private set; } = false;

    bool _preventingDialogue = false;

    public bool CarryableObjectInRange { get; private set; }
    bool _currentlyCarryingAnObject;
    GameObject _carryableObject;

    [SerializeField]
    float _throwForce;

    [SerializeField]
    float _throwObjectDrag;

    LayerMask _normalMask;
    LayerMask _invulnerableMask;
    LayerMask _grappleMask;

    CharacterInput _characterInput;

    [Space(10)]

    #endregion

    #region Crosshair Attributes

    [Header("CrosshairAttributes"), Space(5)]

    [SerializeField]
    SpriteRenderer _crosshairSprite;
    [SerializeField]
    CrosshairFade _crosshairHandle;

    private EventManager2 eventManager2;

    [SerializeField]
    float _crosshairMoveSpeed;

    Vector2 _crosshairMovement;

    CrosshairClamp _crosshairClamp;

    [Space(10)]

    WaitForFixedUpdate _waitForFixedUpdate = new();

    #endregion

    #region Weapon Attributes

    [Header("Weapon Attributes"), Space(5)]

    [SerializeField]
    float _rotateSpeed;

    [SerializeField]
    Transform _aimHandleTransform;

    WeaponOffsetHandle _weaponOffsetHandle;

    float _weaponRotationAngle;

    [SerializeField]
    public PlayerWeapon _gun;
    [SerializeField]
    private Transform _gunLocation;

    [field: Space(10)]

    #endregion

    #region Misc Interaction Variables

    [SerializeField]private bool isFlashing;
    [SerializeField]private SpriteRenderer spriteRenderer;
    [SerializeField]private Color originalColor;
    [SerializeField] private SpriteRenderer eyes;
    [SerializeField] private float colorincrease;
    #endregion

    #region Effects

    [Header("Effects"), Space(5)]

    PlayerEffectHandler _effectHandler;

    [SerializeField]
    TrailRenderer _dodgeSmearRenderer;

    //[Space(10)]

    #endregion

    #region Unity Runtime Functions

    // Start is called before the first frame update

    void CancleCoroutine()
    {
        //StopAllCoroutines();
        spriteRenderer.color = originalColor;
    }

    void DamageFlash()
    {
        StartCoroutine(DamageCoroutine());
        Invoke("CancleCoroutine",0.5f);
    }
    
    IEnumerator DamageCoroutine()
    {
        Color flashColor = Color.red;
        if (!isFlashing)
        {
            isFlashing = true;
            spriteRenderer.color = flashColor;
            yield return new WaitForSeconds(0.2f);
            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(0.2f);
        }
        isFlashing = false;
        spriteRenderer.color = originalColor;
        
    }
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _crosshairClamp = FindObjectOfType<CrosshairClamp>();
        _crosshairHandle = FindObjectOfType<CrosshairFade>();
        _crosshairSprite = _crosshairHandle.GetComponentInChildren<SpriteRenderer>();
        _weaponOffsetHandle = GetComponentInChildren<WeaponOffsetHandle>();
        _effectHandler = GetComponentInChildren<PlayerEffectHandler>();
        _normalMask = LayerMask.NameToLayer("Player");
        _invulnerableMask = LayerMask.NameToLayer("Invulnerable");
        _grappleMask = LayerMask.NameToLayer("Grapple");
    }

    void Start()
    {
        eventManager2 = FindFirstObjectByType<EventManager2>();
        //spriteRenderer = GetComponentInChildren<Playersprite>().spriteRenderer;
        originalColor = spriteRenderer.color;
        eventManager2._equipedEvent += SetGun;
        eventManager2._itemDestroyed += SetGun;
        eventManager2.Damaged += DamageFlash;
        eventManager2._honorDecreased += HonorDecreased;
        eventManager2._honorIncreased += HonorIncreased;
    }

    public void SetGun()
    {
        _gun = GetComponentInChildren<PlayerWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PreventingInput)
        {
            HandleAim();
            HandleMovement();
        }
        
    }

    private void FixedUpdate()
    {
        HandleSpritesAndAnimations();
        
        

        if (_currentlyCarryingAnObject)
        {
            _carryableObject.transform.localPosition = Vector2.zero;
        }
    }

    #endregion

    #region Movement Input and Physics
    private void HandleMovement()
    {
        if (!_rolling && !_grappling)
        {
            _movementSpeed = new Vector2(_xSpeed, _ySpeed);

            _rb.linearVelocity = PlayerMovement();
        }
    }

    public void HandleMovementInput(Vector2 input)
    {
        _movement = input;
    }
    public void HandleDodgeRollInput()
    {
        if(_rb != null)
        {
            if (canRoll && _rb.linearVelocity != Vector2.zero)
            {
                _animator.SetBool("walk", false);
                _animator.SetTrigger("Dodge");
                StartCoroutine(BeginDodgeRollDuration());
                canRoll = false;
            }
        }
    }

    public void HonorDecreased()
    {
        colorincrease += 0.1f;
        eyes.color = Color.Lerp(eyes.color, Color.red, colorincrease);
    }

    public void HonorIncreased()
    {
        colorincrease += 0.1f;
        eyes.color = Color.Lerp(eyes.color, Color.white,  colorincrease);
    }

    Vector2 PlayerMovement()
    {
        return Vector2.Lerp(_rb.linearVelocity, _movement.normalized * _movementSpeed * Time.fixedDeltaTime, playerFriction);
    }

    IEnumerator BeginDodgeRollDuration()
    {
        _rolling = true;
        _rb.AddForce(_movement.normalized * dodgeRollForce);
        GoInvulnerable(_invulnTime);
        //ToggleDashSmear(true);
        yield return new WaitForSeconds(dodgeRollDurationTime);
        _rb.linearVelocity = Vector2.zero;
        StartCoroutine(BeginDodgeRollCoolDown());
        //ToggleDashSmear(false);
        _rolling = false;
        _animator.SetTrigger("walk");
    }

    IEnumerator BeginDodgeRollCoolDown()
    {
        yield return new WaitForSeconds(dodgeRollCooldownTime);
        canRoll = true;
    }

    public bool CurrentlyRolling()
    {
        return _rolling;
    }

    public void PreventInput()
    {
        PreventingInput = true;
        _movementSpeed = Vector2.zero;
        _rb.linearVelocity = Vector2.zero;
    }

    public void AllowInput()
    {
        PreventingInput = false;
    }

    public void GoInvulnerable(float invTime)
    {
        this.gameObject.layer = _invulnerableMask;
        Invoke("GoVulnerable", invTime);
    }

    public void GoVulnerable()
    {
        this.gameObject.layer = _normalMask;
    }
    

    public void GoGrapple()
    {
        this.gameObject.layer = _grappleMask;
    }

    #endregion

    #region Aiming and Crosshair

    //Manages where the player's weapon should be aimin
    private void HandleAim()
    {
        if(!_crosshairClamp.isActiveAndEnabled)
        {
            _weaponRotationAngle = Mathf.Atan2(_crosshairHandle.transform.position.y, _crosshairHandle.transform.position.x) * Mathf.Rad2Deg;
        }
        else
        {
            _weaponRotationAngle = Mathf.Atan2(_crosshairSprite.transform.position.y - transform.position.y, _crosshairSprite.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        }
        
        Quaternion rotation = Quaternion.AngleAxis(_weaponRotationAngle, Vector3.forward);
        _aimHandleTransform.rotation = Quaternion.Slerp(_aimHandleTransform.rotation, rotation, _rotateSpeed * Time.deltaTime);
        _weaponOffsetHandle.OffsetWeaponPos(_weaponRotationAngle);
    }

    //Gets the position of the mouse in world space
    public void HandleAimMouseInput(Vector2 aimPostition)
    {
        if (_crosshairClamp != null)
        {
            _crosshairSprite.enabled = false;
            _crosshairClamp.enabled = false;
            aimPostition = Camera.main.ScreenToWorldPoint(aimPostition) - transform.position;
            _crosshairHandle.transform.position = aimPostition;
            _crosshairHandle.FadeInCrosshair();
        } 
    }

    //Handles where the crosshair should go when using a controller

    #endregion

    #region Animations and Effects

    //All the animation handling happens here...
    public void HandleSpritesAndAnimations()
    {
        if(!PreventingInput)
        {
            if (_movement.x != 0 || _movement.y != 0)
            {
                if (!_effectHandler.RunParticlesPlaying())
                    _effectHandler.PlayRunParticles();
            }
            else
            {
                _effectHandler.StopRunParticles();
            }

            if (_movement.x < 0)
            {
                _playerSpriteObject.transform.localScale = new Vector2(-1, 1);
            }
            else if (_movement.x > 0)
            {
                _playerSpriteObject.transform.localScale = new Vector2(1, 1);
            }
        }
    }

    #endregion

   
    }