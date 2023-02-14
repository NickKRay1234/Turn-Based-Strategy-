using UnityEngine;
public class Unit : MonoBehaviour
    {
        private Vector3 _targetPosition;
        private GridPosition _gridPosition;
        private Vector3 _moveDirection;
        private float StoppingDistance = 0.1f;
        private float Speed = 4.0f;
        [SerializeField] private Animator _unitAnimator;
        private static readonly int IsWalking = Animator.StringToHash("IsWalking");

        private void Awake() =>
            _targetPosition = transform.position;

        private void Start()
        {
            _gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
            LevelGrid.Instance.AddUnitAtGridPosition(_gridPosition, this);
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
