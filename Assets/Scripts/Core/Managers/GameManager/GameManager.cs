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
        _gameStateController = GetComponent<GameStateController>();
        
    }

    private void OnEnable()
    {
        EventManager.Instance.EventController.GetEvent<GameStateEvent>().Data.AddListener(ChangeGameState);
    }

    private void OnDisable()
    {
        EventManager.Instance.EventController.GetEvent<GameStateEvent>().Data.RemoveListener(ChangeGameState);
    }

    public void ChangeGameState(GameStates state)
    {
        _gameStateController.SetNewGameState(state);
        EventManager.Instance.EventController.GetEvent<GameStateEvent>().Data.Execute(state);
    }
}
