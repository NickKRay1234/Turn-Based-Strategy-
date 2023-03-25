using System;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    public static TurnSystem Instance { get; private set; }
    private int _turnNumber;
    private bool isPlayerTurn = true;

    public event EventHandler OnTurnChanged; 

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one TurnSystem! " + transform + "-" + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    
    public void NextTurn()
    {
        _turnNumber++;
        isPlayerTurn = !isPlayerTurn;
        OnTurnChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool IsPlayerTurn() => isPlayerTurn;


    public int GetTurnNumber() => _turnNumber;
}
