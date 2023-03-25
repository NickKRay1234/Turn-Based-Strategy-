using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TurnSystemUI : MonoBehaviour
    {
        [SerializeField] private Button _endTurnBtn;
        [SerializeField] private TextMeshProUGUI _turnNumberText;
        [SerializeField] private GameObject enemyTurnVisualGameObject;

        private void Start()
        {
            _endTurnBtn.onClick.AddListener(() => { TurnSystem.Instance.NextTurn(); });
            TurnSystem.Instance.OnTurnChanged += TurnSystem_OnTurnChanged;
            UpdateTurnText();
            UpdateEnemyTurnVisual();
            UpdateEndTurnButtonVisibility();
        }

        private void TurnSystem_OnTurnChanged(object sender, EventArgs e)
        {
            UpdateTurnText();
            UpdateEnemyTurnVisual();
            UpdateEndTurnButtonVisibility();
        }

        private void UpdateTurnText() =>
            _turnNumberText.text = "TURN " + TurnSystem.Instance.GetTurnNumber();

        private void UpdateEnemyTurnVisual() =>
            enemyTurnVisualGameObject.SetActive(!TurnSystem.Instance.IsPlayerTurn());

        private void UpdateEndTurnButtonVisibility() => 
            _endTurnBtn.gameObject.SetActive(TurnSystem.Instance.IsPlayerTurn());
    }
}
