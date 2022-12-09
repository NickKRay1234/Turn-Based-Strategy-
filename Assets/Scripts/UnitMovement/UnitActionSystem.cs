using UnityEngine;
using System;

namespace UnitMovement
{
    public class UnitActionSystem : MonoBehaviour
    {
        public event EventHandler OnSelectedUnitChanged;
        [SerializeField] private Unit selectedUnit;
        [SerializeField] private LayerMask _unitLayerMask;

        private void Update()
        {
            if (TryHandleUnitSelection()) return;
            if (Input.GetMouseButtonDown(0))
            {
                selectedUnit.Move(MouseWorld.GetPosition());
            }
        }

        private bool TryHandleUnitSelection()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, _unitLayerMask))
            {
                if (raycastHit.transform.TryGetComponent<Unit>(out Unit unit))
                {
                    selectedUnit = unit;
                    return true;
                }
            
            }
            return false;
        }

        private void SetSelectedUnit(Unit unit)
        {
            selectedUnit = unit;
            OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty);
        }

        public Unit GetSelectedUnit()
        {
            return selectedUnit;
        }
    }
}
