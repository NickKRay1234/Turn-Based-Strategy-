using System;
using System.Collections.Generic;
using Actions;
using TMPro;
using UnityEngine;

public class UnitActionSystemUI : MonoBehaviour
{
    [SerializeField] private Transform _actionButtonPrefab;
    [SerializeField] private Transform _actionButtonContainerTransform;
    [SerializeField] private TextMeshProUGUI _actionPointsText;

    private List<ActionButtonUI> _actionButtonUIList;

    private void Awake() =>
        _actionButtonUIList = new List<ActionButtonUI>();

    private void Start()
    {
        UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;
        UnitActionSystem.Instance.OnSelectedActionChanged += UnitActionSystem_OnSelectedActionChanged;
        UnitActionSystem.Instance.OnActionStarted += UnitActionSystem_OnActionStarted;
        UpdateActionPoints();
        CreateUnitActionButtons();
        UpdateSelectedVisual();
    }
    
    private void CreateUnitActionButtons()
    {
        foreach (Transform buttonTransform in _actionButtonContainerTransform)
            Destroy(buttonTransform.gameObject);
        _actionButtonUIList.Clear();
        Unit selectedUnit = UnitActionSystem.Instance.GetSelectedUnit();
        foreach (BaseAction baseAction in selectedUnit.GetBaseActionArray())
        {
            Transform actionButtonTransform = Instantiate(_actionButtonPrefab, _actionButtonContainerTransform);
            ActionButtonUI actionButtonUI = actionButtonTransform.GetComponent<ActionButtonUI>();
            actionButtonUI.SetBaseAction(baseAction);
            _actionButtonUIList.Add(actionButtonUI);
        }
    }
    
    private void UnitActionSystem_OnSelectedUnitChanged(object sender, EventArgs e)
    {
        CreateUnitActionButtons();
        UpdateSelectedVisual();
        UpdateActionPoints();
    }
    
    private void UnitActionSystem_OnSelectedActionChanged(object sender, EventArgs e) => UpdateSelectedVisual();
    private void UnitActionSystem_OnActionStarted(object sender, EventArgs e) => UpdateActionPoints();

    private void UpdateSelectedVisual()
    {
        foreach (ActionButtonUI actionButtonUI in _actionButtonUIList)
            actionButtonUI.UpdateSelectedVisual();
    }

    private void UpdateActionPoints()
    {
        Unit selectedUnit = UnitActionSystem.Instance.GetSelectedUnit();
        _actionPointsText.text = "Action Points: " + selectedUnit.GetActionPoints();
    }
}
