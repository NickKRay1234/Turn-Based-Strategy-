using System.Collections.Generic;
using UnityEngine;

public class MoveAction : MonoBehaviour
{
    [SerializeField] private Animator _unitAnimator;
    [SerializeField] private int maxMoveDistance = 4;
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private Vector3 _targetPosition;
    private Vector3 _moveDirection;
    private float StoppingDistance = 0.1f;
    private float Speed = 4.0f;
    private Unit _unit;
    
    private void Awake()
    {
        _unit = GetComponent<Unit>();
        _targetPosition = transform.position;
    }

    private void Update()
    {
        StoppingDistance = 0.1f;
        if (Vector3.Distance(transform.position, _targetPosition) > StoppingDistance)
        {
            _moveDirection = (_targetPosition - transform.position).normalized;
            Speed = 4.0f;
            transform.position += _moveDirection * (Speed * Time.deltaTime);
            //transform.forward = _moveDirection;
            float rotateSpeed = 10f;
            transform.forward = Vector3.Lerp(transform.forward, _moveDirection, Time.deltaTime * rotateSpeed);
            _unitAnimator.SetBool(IsWalking, true);
        }
        else
        {
            _unitAnimator.SetBool(IsWalking, false);
        }
    }
    
    public void Move(GridPosition gridPosition)
    {
        _targetPosition = LevelGrid.Instance.GetWorldPosition(gridPosition);
    }

    public bool IsValidActionGridPosition(GridPosition gridPosition)
    {
        List<GridPosition> validGridPositionList = GetValidActionGridPositionList();
        return validGridPositionList.Contains(gridPosition);
    }

    public List<GridPosition> GetValidActionGridPositionList()
    {
        List<GridPosition> validGridPositionList = new List<GridPosition>();
        GridPosition unitGridPosition = _unit.GetGridPosition();
        for (int x = -maxMoveDistance; x <= maxMoveDistance; x++)
        {
            for (int z = -maxMoveDistance; z <= maxMoveDistance; z++)
            {
                GridPosition offsetGridPosition = new GridPosition(x, z);
                GridPosition testGridPosition = unitGridPosition + offsetGridPosition;
                if(!LevelGrid.Instance.IsValidGridPosition(testGridPosition)) continue;
                if(unitGridPosition == testGridPosition) continue;
                if(LevelGrid.Instance.HasAnyUnitOnGridPosition(testGridPosition)) continue;
                validGridPositionList.Add(testGridPosition);
                Debug.Log(testGridPosition);
            }
        }
        return validGridPositionList;
    }

}
