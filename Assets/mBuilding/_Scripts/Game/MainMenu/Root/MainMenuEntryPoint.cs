using mBuilding.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuEntryPoint : MonoBehaviour
{
    //[SerializeField] private GameObject _sceneRootBinder;
    public event Action GoToGameplaySceneRequested;

    [SerializeField] private UIMainMenuRootBinder _sceneUIRootPrefab;

    public void Run(UIRootView uIRootView)
    {
        var uiScene = Instantiate(_sceneUIRootPrefab);
        uIRootView.AttachSceneUI(uiScene.gameObject);

        uiScene.GoToGameplayButtonClicked += () =>
        {
            GoToGameplaySceneRequested?.Invoke();
        };

    }
}
