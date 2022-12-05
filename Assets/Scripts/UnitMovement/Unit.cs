using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Vector3 _targetPosition;
    private Vector3 _moveDirection;
    private const float Speed = 4.0f;
    

    private void Update()
    {
        _moveDirection = (_targetPosition - transform.position).normalized;
        transform.position += _moveDirection * (Speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.T))
        {
            Move(new Vector3(4, 0, 4));
        }
    }

    private void Move(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
    }
}
