using System.Collections.Generic;
using UnityEngine;
using System;

namespace Actions
{
    public class MoveAction : BaseAction
    {
        [SerializeField] private Animator _unitAnimator;
        [SerializeField] private int maxMoveDistance = 4;
        private static readonly int IsWalking = Animator.StringToHash("IsWalking");
        private Vector3 _targetPosition;
        private float StoppingDistance = 0.1f;
        private float Speed = 4.0f;

        protected override void Awake()
        {
            base.Awake();
            _targetPosition = transform.position;
        }

        public override string GetActionName() => "Move";

        private void Update()
        {
            if(!isActive) return;
            StoppingDistance = 0.1f;
            Vector3 _moveDirection = (_targetPosition - transform.position).normalized;
            if (Vector3.Distance(transform.position, _targetPosition) > StoppingDistance)
            {
                Speed = 4.0f;
                transform.position += _moveDirection * (Speed * Time.deltaTime);
                _unitAnimator.SetBool(IsWalking, true);
            }
            else
            {
                _unitAnimator.SetBool(IsWalking, false);
                isActive = false;
                onActionComplete();
            }

            float rotateSpeed = 10f;
            transform.forward = Vector3.Lerp(transform.forward, _moveDirection, Time.deltaTime * rotateSpeed);
        }
    
        public void Move(GridPosition gridPosition, Action onActionComplete)
        {
            this.onActionComplete = onActionComplete;
            _targetPosition = LevelGrid.Instance.GetWorldPosition(gridPosition);
            isActive = true;
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
}
