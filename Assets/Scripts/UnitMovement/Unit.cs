using UnityEngine;

public class Unit : MonoBehaviour
{
    private Vector3 _targetPosition;
    private Vector3 _moveDirection;
    private const  float StoppingDistance = 0.1f;
    private const float Speed = 4.0f;
    

    private void Update()
    {
        if (Vector3.Distance(transform.position, _targetPosition) > StoppingDistance)
        {
            _moveDirection = (_targetPosition - transform.position).normalized;
            transform.position += _moveDirection * (Speed * Time.deltaTime);
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
