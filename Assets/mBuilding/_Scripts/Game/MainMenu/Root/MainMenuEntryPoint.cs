using mBuilding.Scripts;
using R3;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuEntryPoint : MonoBehaviour
{
    //[SerializeField] private GameObject _sceneRootBinder;

    [SerializeField] private UIMainMenuRootBinder _sceneUIRootPrefab;

    public Observable<MainMenuExitParams> Run(UIRootView uIRootView, MainMenuEnterParams enterParams)
    {
        ///setup menu ui
        var uiScene = Instantiate(_sceneUIRootPrefab);
        uIRootView.AttachSceneUI(uiScene.gameObject);

        ///bind button exit from menu || start gameplay
        var exitSignalSubj = new Subject<Unit>();
        uiScene.Bind(exitSignalSubj);

        /// setup game Enter Params
        string saveFileName = "noviFile.save";
        int levelNumber = 69;
        var gameplayEnterParams = new GameplayEnterParams(Scenes.GAMEPLAY, saveFileName, levelNumber);

        var mainMenuExitParams = new MainMenuExitParams(gameplayEnterParams);

        Observable<MainMenuExitParams> exitToGameplaySignal = exitSignalSubj.Select(_ => mainMenuExitParams);
        Debug.Log($"Mainmenu entry POINT Results: {enterParams?.Results}");

        return exitToGameplaySignal;
    }
}                                                   
