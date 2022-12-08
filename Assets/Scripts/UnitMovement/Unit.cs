using UnityEngine;

public class Unit : MonoBehaviour
{
    private Vector3 _targetPosition;
    private Vector3 _moveDirection;
    private const  float StoppingDistance = 0.1f;
    private const float Speed = 4.0f;
    [SerializeField] private Animator _unitAnimator;
    

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

        if (Input.GetMouseButtonDown(0))
        {
            Move(MouseWorld.GetPosition());
        }
    }

    private void Move(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
    }
}
