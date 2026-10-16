using System.Security.Cryptography;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public abstract class StateBase
{

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}

public sealed class IdleState : StateBase
{
    private PlayerController _controller;
    public IdleState(PlayerController controller)
    {
        _controller = controller;
    }
    public override void Enter()
    {
        Debug.Log("<color=blue> Idle 상태 진입 </color>");
        _controller.AttackInputRef.action.performed += TransitionAttack;
    }

    public override void Update()
    {

        Debug.Log("<color=blue> Idle 상태 </color>");
    }

    public override void Exit()
    {
        Debug.Log("<color=blue> Idle 상태 빠져나가기 </color>");
        _controller.AttackInputRef.action.performed -= TransitionAttack;
    }

    private void TransitionAttack(InputAction.CallbackContext ctx)
    {
        _controller.SetState(_controller.Attack);

    }

}

public sealed class AttackState : StateBase
{
    private PlayerController _controller;
    public AttackState(PlayerController controller)
    {
        _controller = controller;
    }
    public override void Enter()
    {
        Debug.Log("<color=green> Attack 상태 진입 </color>");
    }

    public override void Update()
    {
        Debug.Log("<color=green> Attack 상태  </color>");
        _controller.SetState(_controller.Idle);   
    }

    public override void Exit()
    {
        Debug.Log("<color=green> Attack 상태 빠져나감 </color>");
    }

}
public sealed class DeadState : StateBase
{
    private PlayerController _controller;
    public DeadState(PlayerController controller)
    {
        _controller = controller;
    }
    public override void Enter()
    {
        Debug.Log("크아악");
    }

    public override void Update()
    {
        Debug.Log("<color=red> Dead 상태  </color>");
    }

    public override void Exit()
    {
     
    }

}
