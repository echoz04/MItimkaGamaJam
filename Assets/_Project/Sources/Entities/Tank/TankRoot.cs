using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankRoot : MonoBehaviour, ICharacter
{
    public Transform Transform => transform;

    [SerializeField] private Transform _gunTransform;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _gunRotateSpeed;
    [SerializeField] private float _gunRotateOffSet = 180f;

    private TankInput _input;
    private Camera _camera;
    private float _moveDirection;
    private float _rotateDirection;

    private Action<InputAction.CallbackContext> _onMovePerformed;
    private Action<InputAction.CallbackContext> _onMoveCanceled;
    private Action<InputAction.CallbackContext> _onRotatePerformed;
    private Action<InputAction.CallbackContext> _onRotateCanceled;

    private void Start()
    {
        _input = new TankInput();
        _input.Enable();

        _camera = Camera.main;

        _onMovePerformed = ctx => _moveDirection = ctx.ReadValue<float>();
        _onMoveCanceled = ctx => _moveDirection = 0;
        _onRotatePerformed = ctx => _rotateDirection = ctx.ReadValue<float>();
        _onRotateCanceled = ctx => _rotateDirection = 0;

        _input.Movement.Move.performed += _onMovePerformed;
        _input.Movement.Move.canceled += _onMoveCanceled;

        _input.Movement.Rotate.performed += _onRotatePerformed;
        _input.Movement.Rotate.canceled += _onRotateCanceled;
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
        Move();
        Rotate();
        Rotategun();
    }

    public void UpgradeStats()
    {
        _moveSpeed *= 2;
        _rotateSpeed *= 2;
        _gunRotateSpeed *= 2;
    }

    private void Move()
    {
        Vector3 movement = -transform.right * _moveDirection * _moveSpeed * Time.deltaTime;

        transform.Translate(movement, Space.World);
    }

    private void Rotate()
    {
        float rotationAmount = -_rotateDirection * _rotateSpeed * Time.deltaTime;

        transform.Rotate(0f, 0f, rotationAmount);
    }

    private void Rotategun()
    {
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPosition = _camera.ScreenToWorldPoint(mousePosition);
        mouseWorldPosition.z = 0f;

        Vector3 direction = mouseWorldPosition - _gunTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        float currentAngle = _gunTransform.eulerAngles.z;
        float smoothAngle = Mathf.MoveTowardsAngle(currentAngle, angle + _gunRotateOffSet, Time.deltaTime * _gunRotateSpeed);

        _gunTransform.rotation = Quaternion.Euler(0f, 0f, smoothAngle);
    }
}
