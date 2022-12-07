using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    private Camera _camera;
    private RaycastHit _raycastHit;
    [SerializeField] private LayerMask _mousePlaneLayerMask;
    private Ray _ray;
    private void Start()
    {
        _camera = Camera.main;
    }

    private void FixedUpdate()
    {
        Physics.Raycast(GetRay(), out _raycastHit, float.MaxValue, _mousePlaneLayerMask);
        transform.position = _raycastHit.point;
    }
    
    private Ray GetRay() => _camera.ScreenPointToRay(Input.mousePosition);
}
 