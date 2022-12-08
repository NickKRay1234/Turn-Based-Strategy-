using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    [SerializeField] private LayerMask _mousePlaneLayerMask;
    private static MouseWorld instance;
    private static Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        instance = this;
    }

    private void Update()
    {
        transform.position = MouseWorld.GetPosition();
    }

    private static Vector3 GetPosition()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance._mousePlaneLayerMask);
        return raycastHit.point;
    }
}
 