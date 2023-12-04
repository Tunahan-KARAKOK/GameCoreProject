using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameStateController))]
public class GameManager : Singleton<GameManager>
{
    private IGameStateController _gameStateController;
    
    private void Awake()
    {
        _gameStateController = GetComponent<IGameStateController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeGameState(GameStates.InGameState);
        }
    }

    public void ChangeGameState(GameStates state)
    {
        _gameStateController.SetNewGameState(state);
    }
}
