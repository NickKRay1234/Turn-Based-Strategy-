using UnityEngine;

namespace Actions
{
    public abstract class BaseAction : MonoBehaviour
    {
        protected Unit _unit;
        protected bool isActive;

        protected virtual void Awake()
        {
            _unit = GetComponent<Unit>();
        }
    }
}
