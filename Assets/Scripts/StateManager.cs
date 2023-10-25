using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static StateManager Instance;
    private GameState _state;

    private void Awake()
    {
        Instance = this;
    }

    // Add a property to get the current state
    public GameState CurrentState => _state;

    private void Start()
    {
        ChangeState(GameState.SpawnBlock);
    }

    public void ChangeState(GameState newState)
    {
        _state = newState;

        switch (newState)
        {
            case GameState.SpawnBlock:
                Events.OnBlockSpawned.Invoke();
                break;
            case GameState.Dragging:
                Events.OnBlockListen.Invoke();
                break;
            case GameState.Throwing:
                Debug.Log("Throwing");
                break;
            case GameState.Moving:
                break;
            case GameState.Lose:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
}

public enum GameState
{
    SpawnBlock,
    Dragging,
    Throwing,
    Moving,
    Lose
}