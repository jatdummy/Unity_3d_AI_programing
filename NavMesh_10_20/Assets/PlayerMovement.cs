using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    // 마우스 클릭 -> 클릭한 곳의 좌표 받아서 이동하기(Ground 위에서만)
    [SerializeField] private LayerMask _groundLayer;

    [SerializeField] private InputActionReference _mouseLeftInput;
    [SerializeField] private InputActionReference _mousePosition;
    [SerializeField] private Transform _goalTransform;

    private Camera _cam;
    private NavMeshAgent _agent;


    private void Awake() => CacheComponents();
    private void OnEnable() => BindInputEvents();
    private void Start() => Init();
    private void Update() => MoveToGoal();

    private void CacheComponents()
    {
        _cam = Camera.main;
        _agent = GetComponent<NavMeshAgent>();
    }

    private void BindInputEvents()
    {
        _mouseLeftInput.action.Enable();
        _mousePosition.action.Enable();
        _mouseLeftInput.action.performed += OnMouseLeftButtonDown;
    }

    private void OnMouseLeftButtonDown(InputAction.CallbackContext context)
    {
        SetGoalPosition();
    }

    private void Init()
    {
        _goalTransform.position = transform.position;
    }

    private void SetGoalPosition()
    {
        Vector2 screen = _mousePosition.action.ReadValue<Vector2>();
        Ray ray = _cam.ScreenPointToRay(screen);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _groundLayer))
        {
            _goalTransform.position = hit.point;
        }
    }

    private void MoveToGoal()
    {
        _agent.SetDestination(_goalTransform.position);
        
        //transform.position = Vector3.MoveTowards(transform.position, _goalTransform.position, 3 * Time.deltaTime);
    }
}