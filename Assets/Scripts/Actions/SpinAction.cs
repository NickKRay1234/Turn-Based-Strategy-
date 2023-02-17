using UnityEngine;
using System;
using System.Collections.Generic;

namespace Actions
{
    public class SpinAction : BaseAction
    {
        private float _totalSpinAmount;
        private void Update()
        {
            if (!isActive) return;
            float spinAddAmount = 360f * Time.deltaTime;
            transform.eulerAngles += new Vector3(0, spinAddAmount,0);

            _totalSpinAmount += spinAddAmount;
            if (_totalSpinAmount >= 360f)
            {
                isActive = false;
                onActionComplete();
            }
        }
        
        public override void TakeAction(GridPosition gridPosition, Action onActionComplete)
        {
            this.onActionComplete = onActionComplete;
            isActive = true;
            _totalSpinAmount = 0f;
        }

        public override string GetActionName() => "Spin";

        public override List<GridPosition> GetValidActionGridPositionList()
        {
            List<GridPosition> validGridPositionList = new List<GridPosition>();
            GridPosition unitGridPosition = _unit.GetGridPosition();
            return new List<GridPosition>() { unitGridPosition };
        }
    }
}
