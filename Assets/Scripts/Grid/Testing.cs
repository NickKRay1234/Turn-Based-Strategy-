using UnitMovement;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private Transform _gridDebugObjectPrefab;
    private GridSystem _gridSystem;
    private void Start()
    {
        _gridSystem = new GridSystem(10, 10, 2f);
        _gridSystem.CreateDebugObjects(_gridDebugObjectPrefab);
        Debug.Log(new GridPosition(5,7));
    }

    private void Update()
    {
        Debug.Log(_gridSystem.GetGridPosition(MouseWorld.GetPosition()));
    }
}
