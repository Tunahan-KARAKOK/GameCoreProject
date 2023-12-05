using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UiController))]
public class UiManager : Singleton<UiManager>
{
    private UiController _uiController;

    private void Awake()
    {
        _uiController = GetComponent<UiController>();
    }
}


