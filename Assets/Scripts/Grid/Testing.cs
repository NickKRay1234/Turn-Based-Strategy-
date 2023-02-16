using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private Unit _unit;

    private void Update()
    {
        GridSystemVisual.Instance.HideAllGridPosition();
        GridSystemVisual.Instance.ShowGridPositionList(_unit.GetMoveAction().GetValidActionGridPositionList());
    }
}
