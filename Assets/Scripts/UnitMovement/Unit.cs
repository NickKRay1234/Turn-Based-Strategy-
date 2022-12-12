using UnityEngine;

namespace UnitMovement
{
    public class Unit : MonoBehaviour
    {
        private Vector3 _targetPosition;
        private GridPosition _gridPosition;
        private Vector3 _moveDirection;
        private const  float StoppingDistance = 0.1f;
        private const float Speed = 4.0f;
        [SerializeField] private Animator _unitAnimator;

        private void Awake()
        {
            _targetPosition = transform.position;
        }

        private void Start()
        {
            _gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
            LevelGrid.Instance.SetUnitAtGridPosition(_gridPosition, this);
        }

        private void Update()
        {
            if (Vector3.Distance(transform.position, _targetPosition) > StoppingDistance)
            {
                _moveDirection = (_targetPosition - transform.position).normalized;
                transform.position += _moveDirection * (Speed * Time.deltaTime);
                //transform.forward = _moveDirection;
                float rotateSpeed = 10f;
                transform.forward = Vector3.Lerp(transform.forward, _moveDirection, Time.deltaTime * rotateSpeed);
                _unitAnimator.SetBool("IsWalking", true);
            }
            else
            {
                _unitAnimator.SetBool("IsWalking", false);
            }

            GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
            if (newGridPosition != _gridPosition)
            {
                // Unit changed Grid Position
                LevelGrid.Instance.UnitMovedGridPosition(this, _gridPosition, newGridPosition);
                _gridPosition = newGridPosition;
            }
            
        }

        public void Move(Vector3 targetPosition)
        {
            _targetPosition = targetPosition;
        }
    }
}
