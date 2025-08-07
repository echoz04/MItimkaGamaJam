using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankRoot : MonoBehaviour, ICharacter
{
    public static ICharacter Instance { get; private set; }

    public Transform Transform => transform;
    public bool IsMoving => _currentMoveInput > 0.25f || _rotateDirection > 0.25f;

    private HealthComponent healthComponent;

    [SerializeField] private Transform _gunTransform;

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotateSpeed = 100f;
    [SerializeField] private float _gunRotateSpeed = 200f;
    [SerializeField] private float _gunRotateOffSet = 180f;
    [SerializeField] private float _accelerationTime = 0.2f;

    private TankInput _input;
    private Camera _camera;
    private float _targetMoveInput;
    private float _currentMoveInput;
    private float _moveVelocityRef;

    private float _rotateDirection;

    private Action<InputAction.CallbackContext> _onMovePerformed;
    private Action<InputAction.CallbackContext> _onMoveCanceled;
    private Action<InputAction.CallbackContext> _onRotatePerformed;
    private Action<InputAction.CallbackContext> _onRotateCanceled;

    public event Action OnDestroyed;

    public bool IsDestroyed = false;

    private void Awake()
    {
        Instance = this;

        _input = new TankInput();
        _input.Enable();

        _camera = Camera.main;

        _onMovePerformed = ctx => _targetMoveInput = ctx.ReadValue<float>();
        _onMoveCanceled = ctx => _targetMoveInput = 0f;

        _onRotatePerformed = ctx => _rotateDirection = ctx.ReadValue<float>();
        _onRotateCanceled = ctx => _rotateDirection = 0f;

        _input.Movement.Move.performed += _onMovePerformed;
        _input.Movement.Move.canceled += _onMoveCanceled;

        _input.Movement.Rotate.performed += _onRotatePerformed;
        _input.Movement.Rotate.canceled += _onRotateCanceled;
    }

    private void Start()
    {
        // MaxScoreDisplayer.Instance.Display();

        healthComponent = Transform.GetComponent<HealthComponent>();

        healthComponent.OnHealthEnded += () =>
        {
            OnDestroyed?.Invoke();
            IsDestroyed = true;
            Debug.Log("Tank destroyed");
            // Destroy(this);
        };

        healthComponent.OnHealthChanged += (delta) =>
        {
            MaxScoreDisplayer.Instance.SetMaxScore(ScoreCounter.Instance.GetScore());

            if (delta > 0)
            {

            }
        };
    }

    private void OnDestroy()
    {
        _input.Movement.Move.performed -= _onMovePerformed;
        _input.Movement.Move.canceled -= _onMoveCanceled;
        _input.Movement.Rotate.performed -= _onRotatePerformed;
        _input.Movement.Rotate.canceled -= _onRotateCanceled;
    }

    private void Update()
    {
        if (IsDestroyed)
        {
            return;
        }

        UpdateMovementInput();
        Move();
        Rotate();
        RotateGun();
    }

    private void UpdateMovementInput()
    {
        _currentMoveInput = Mathf.SmoothDamp(_currentMoveInput, _targetMoveInput, ref _moveVelocityRef, _accelerationTime);
    }

    private void Move()
    {
        Vector3 movement = -transform.right * _currentMoveInput * _moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }

    private void Rotate()
    {
        float rotationAmount = -_rotateDirection * _rotateSpeed * Time.deltaTime;
        transform.Rotate(0f, 0f, rotationAmount);
    }

    private void RotateGun()
    {
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPosition = _camera.ScreenToWorldPoint(mousePosition);
        mouseWorldPosition.z = 0f;

        Vector3 direction = mouseWorldPosition - _gunTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        float tankRotationZ = transform.eulerAngles.z;
        float targetAngle = angle + _gunRotateOffSet - tankRotationZ;

        float currentGunAngle = _gunTransform.localEulerAngles.z;
        float smoothAngle = Mathf.MoveTowardsAngle(currentGunAngle, targetAngle, Time.deltaTime * _gunRotateSpeed);

        _gunTransform.localRotation = Quaternion.Euler(0f, 0f, smoothAngle);
    }

    public void UpgradeStats()
    {
        _moveSpeed *= 2;
        _rotateSpeed *= 2;
        _gunRotateSpeed *= 2;
    }
}
