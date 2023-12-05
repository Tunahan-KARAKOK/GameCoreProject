using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Core.Utilities.Results;
using UnityEngine;

public class UiController : MonoBehaviour, IUiController
{
    private List<UiPanel> _allPanels;
    
    private IMainMenuPanel _mainMenuPanel;
    private IInGamePanel _inGamePanel;
    private IPausePanel _pausePanel;
    private IShopPanel _shopPanel;
    private ILevelSuccessPanel _levelSuccessPanel;
    private ILevelFailedPanel _levelFailedPanel;
    
    private void Awake()
    {
        _mainMenuPanel = FindObjectOfType<MainMenuPanel>(true);
        _inGamePanel = FindObjectOfType<InGamePanel>(true);
        _pausePanel = FindObjectOfType<PausePanel>(true);
        _shopPanel = FindObjectOfType<ShopPanel>(true);
        _levelSuccessPanel = FindObjectOfType<LevelSuccessPanel>(true);
        _levelFailedPanel = FindObjectOfType<LevelFailedPanel>(true);
        
        GetAllPanels();
        CloseAllPanels();
        OpenSpecificPanel(_mainMenuPanel);
    }

    public Result GetAllPanels()
    {
        _allPanels = new List<UiPanel>();
        _allPanels = FindObjectsOfType<UiPanel>(true).ToList();
        return new SuccessResult();
    }

    public Result CloseAllPanels()
    {
        foreach (var panel in _allPanels)
        {
            panel.gameObject.SetActive(false);
        }

        return new SuccessResult();
    }

    public Result OpenSpecificPanel(IUiPanel uiPanel)
    {
        var result = _allPanels.FirstOrDefault(x => x == uiPanel);
        if (result)
        {
            CloseAllPanels();
            result.gameObject.SetActive(true);   
            return new SuccessResult();
        }

        return new ErrorResult("spesific panel doesnt exist");
    }

}
