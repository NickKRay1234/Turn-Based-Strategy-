using UnityEngine;
using System;
using System.Collections.Generic;

namespace Actions
{
    public abstract class BaseAction : MonoBehaviour
    {
        protected Unit _unit;
        protected bool isActive;
        protected Action onActionComplete;

        protected virtual void Awake()
        {
            _unit = GetComponent<Unit>();
        }

        public abstract string GetActionName();
        public abstract void TakeAction(GridPosition gridPosition, Action onActionComplete);

        public virtual bool IsValidActionGridPosition(GridPosition gridPosition)
        {
            List<GridPosition> validGridPositionList = GetValidActionGridPositionList();
            return validGridPositionList.Contains(gridPosition);
        }

        public abstract List<GridPosition> GetValidActionGridPositionList();
    }
}
