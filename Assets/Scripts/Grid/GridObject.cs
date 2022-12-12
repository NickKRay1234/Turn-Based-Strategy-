using UnitMovement;
using UnityEngine;

public class GridObject : MonoBehaviour
{
    private GridSystem _gridSystem;
    private GridPosition _gridPosition;
    private Unit _unit;

    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        _gridPosition = gridPosition;
        _gridSystem = gridSystem;
    }

    public override string ToString()
    {
        return _gridPosition.ToString() + '\n' + _unit;
    }

    public void SetUnit(Unit unit)
    {
        _unit = unit;
    }

    public Unit GetUnit()
    {
        return _unit;
    }

}
