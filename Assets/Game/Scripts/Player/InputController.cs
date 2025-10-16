using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] private CharacterMovement _characterMovement;
    [SerializeField] private Vector2 _forceDirection;
    private InputSystem_Actions _playerInputActionMap;
    private InputAction _moveDirection;


    void Awake()
    {
        _playerInputActionMap = new InputSystem_Actions();
    }
    void OnEnable()
    {
        _playerInputActionMap.Player.Jump.started += PressJumpButton;
        _moveDirection = _playerInputActionMap.Player.Move;
        _playerInputActionMap.Enable();
    }

    void OnDisable()
    {
        _playerInputActionMap.Player.Jump.started -= PressJumpButton;
        _playerInputActionMap.Disable();
    }

    void Update()
    {
        _forceDirection = _moveDirection.ReadValue<Vector2>();
        if (_forceDirection.x != 0)
        {
            _characterMovement.DoMove(_forceDirection);
            _characterMovement.MoveAnimation(true);
        }
        else _characterMovement.MoveAnimation(false);
    }
    private void PressJumpButton(InputAction.CallbackContext context)
    {
        _characterMovement.DoJump(_forceDirection);
    }
}
