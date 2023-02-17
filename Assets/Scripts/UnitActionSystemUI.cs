using System;
using Actions;
using UnityEngine;

public class UnitActionSystemUI : MonoBehaviour
{
    [SerializeField] private Transform _actionButtonPrefab;
    [SerializeField] private Transform _actionButtonContainerTransform;
    private void Start()
    {
        UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;
        CreateUnitActionButtons();
    }
    
    private void CreateUnitActionButtons()
    {
        foreach (Transform buttonTransform in _actionButtonContainerTransform)
            Destroy(buttonTransform.gameObject);
        Unit selectedUnit = UnitActionSystem.Instance.GetSelectedUnit();
        foreach (BaseAction baseAction in selectedUnit.GetBaseActionArray())
        {
            Transform actionButtonTransform = Instantiate(_actionButtonPrefab, _actionButtonContainerTransform);
            ActionButtonUI actionButtonUI = actionButtonTransform.GetComponent<ActionButtonUI>();
            actionButtonUI.SetBaseAction(baseAction);
        }
    }
    
    private void UnitActionSystem_OnSelectedUnitChanged(object sender, EventArgs e)
    {
        CreateUnitActionButtons();
    }
}
