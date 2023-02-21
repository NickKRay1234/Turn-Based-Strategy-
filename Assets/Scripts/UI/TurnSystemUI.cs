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

        private void Start()
        {
            _endTurnBtn.onClick.AddListener(() => { TurnSystem.Instance.NextTurn(); });
            TurnSystem.Instance.OnTurnChanged += TurnSystem_OnTurnChanged;
            UpdateTurnText();
        }

        private void TurnSystem_OnTurnChanged(object sender, EventArgs e) =>
            UpdateTurnText();

        private void UpdateTurnText() =>
            _turnNumberText.text = "TURN " + TurnSystem.Instance.GetTurnNumber();
    }
}
