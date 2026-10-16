using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerController : MonoBehaviour, IStateEvent, IDamageable
{
    [SerializeField] private InputActionReference _attackInput;
    [SerializeField] private InputActionReference _damageInput;

    private StateBase _idle;
    private StateBase _attack;
    private StateBase _dead;
    public Action<StateBase> OnStateChange { get; set; }

    public InputActionReference AttackInputRef => _attackInput;
    public StateBase Idle => _idle;
    public StateBase Attack => _attack;
    private void Awake()
    {
        _idle = new IdleState(this);
        _attack = new AttackState(this);
        _dead = new DeadState(this);
    }

    private void OnEnable()
    {
        _attackInput.action.Enable();
        _damageInput.action.Enable();
        _damageInput.action.performed += OnDamageInput;
    }
    private void Start()
    {
        OnStateChange?.Invoke(_idle);
    }

    public void SetState(StateBase state)
    {
        OnStateChange?.Invoke(state);
    }
    private void OnDamageInput(InputAction.CallbackContext ctx)
    {
        TakeDamage(1);
    }

    public void TakeDamage(int damage)
    {
        // 데미지 받으면 캐릭터 죽음.

        // 체력이 0 이하라면
        OnStateChange?.Invoke(_dead);

    }
}
