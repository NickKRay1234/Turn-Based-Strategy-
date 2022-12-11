using UnityEngine;

public class GridObject : MonoBehaviour
{
    private GridSystem _gridSystem;
    private GridPosition _gridPosition;

    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        _gridPosition = gridPosition;
        _gridSystem = gridSystem;
    }

    public override string ToString()
    {
        return _gridPosition.ToString();
    }

}
