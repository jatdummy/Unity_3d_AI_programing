using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private StateBase _current;
    private IStateEvent _stateEvent;

    private void Awake()
    {
        _stateEvent = GetComponent<IStateEvent>();
    }

    private void OnEnable()
    {
        _stateEvent.OnStateChange += ChangeState;
    }

    public void Update()
    {
        _current?.Update();
    }

    private void OnDisable()
    {
        _stateEvent.OnStateChange -= ChangeState;
    }

    public void ChangeState(StateBase state)
    {
        // state == null 이면?
        // _current == state 인 상태이면?
        // _current == null 이면?
        if (state == null || _current == state) return;


        // 이전 상태의 Exit()
        _current?.Exit();
        // 현재 상태 변경
        _current = state;
        // 현재 상태에 Enter()
        _current.Enter();
    }

}
