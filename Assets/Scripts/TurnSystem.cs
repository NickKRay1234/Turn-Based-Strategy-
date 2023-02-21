using System;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    public static TurnSystem Instance { get; private set; }
    private int _turnNumber;

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
        OnTurnChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetTurnNumber() => _turnNumber;
}
