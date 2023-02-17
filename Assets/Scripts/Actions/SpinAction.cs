using UnityEngine;
using System;

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
        public void Spin(Action onActionComplete)
        {
            this.onActionComplete = onActionComplete;
            isActive = true;
            _totalSpinAmount = 0f;
        }
    }
}
