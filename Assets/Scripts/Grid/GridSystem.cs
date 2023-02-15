using UnityEngine;

public sealed class GridSystem
{
    private int _width;
    private int _height;
    private float _cellSize;
    private GridObject[,] gridObjectArray;
    
    public GridSystem(int width, int height, float cellSize)
    {
        _width = width;
        _height = height;
        _cellSize = cellSize;

        gridObjectArray = new GridObject[_width, _height];
        for (int x = 0; x < _width; x++)
        {
            for (int z = 0; z < _height; z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);
                gridObjectArray[x,z] = new GridObject(this, gridPosition);
            }
        }
    }

    public Vector3 GetWorldPosition(GridPosition gridPosition) =>
        new Vector3(gridPosition.x, 0, gridPosition.z) * _cellSize;

    public GridPosition GetGridPosition(Vector3 worldPosition) =>
        new (Mathf.RoundToInt(worldPosition.x / _cellSize), Mathf.RoundToInt(worldPosition.z / _cellSize));
    
    public GridObject GetGridObject(GridPosition gridPosition) =>
        gridObjectArray[gridPosition.x, gridPosition.z];

    public void CreateDebugObjects(Transform debugPrefab)
    {
        for (int x = 0; x < _width; x++)
        {
            for (int z = 0; z < _height; z++)
            { 
                GridPosition gridPosition = new GridPosition(x, z);
               Transform debugTransform = Object.Instantiate(debugPrefab, GetWorldPosition(gridPosition), Quaternion.identity);
               GridDebugObject gridDebugObject = debugTransform.GetComponent<GridDebugObject>();
               gridDebugObject.SetGridObject(gridObjectArray[x,z]);
            }
        }
    }

    public bool IsValidGridPosition(GridPosition gridPosition) =>
        gridPosition.x >= 0 &&
        gridPosition.z >= 0 &&
        gridPosition.x < _width &&
        gridPosition.z < _height;
}
