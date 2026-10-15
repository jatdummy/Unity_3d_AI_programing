using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Vector2 _moveInput;
    [SerializeField] private InputActionReference _moveInputAction;
    [SerializeField] private InputActionReference _jumpInputAction;
    // 직접 바인딩
    [SerializeField] private InputAction _ii;

    private void OnEnable()
    {
        // start
        // performed
        // canceled
        _moveInputAction.action.Enable();
        _moveInputAction.action.performed += OnMove;

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
        Debug.Log(_moveInput);
    }

    public void OnMoveStop(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
        Debug.Log(_moveInput);
    }
    
    public void OnJump()
    {
        Debug.Log("점핑 예 점핑 예");
    }

}
