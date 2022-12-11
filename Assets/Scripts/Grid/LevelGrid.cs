using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    [SerializeField] private Transform _gridDebugObjectPrefab;
    private GridSystem _gridSystem;
    private void Awake()
    {
        _gridSystem = new GridSystem(10, 10, 2f);
        _gridSystem.CreateDebugObjects(_gridDebugObjectPrefab);
    }

    public void SetUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
        
    }

    public Unit GetUnitAtGridPosition(GridPosition gridPosition)
    {
        
    }

    public void ClearUnitAtGridPosition(GridPosition gridPosition)
    {
        
    }
}
