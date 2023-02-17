using UnityEngine;
using System;

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
    }
}
