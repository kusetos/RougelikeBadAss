using R3;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace mBuilding.Scripts
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        //[SerializeField] private GameObject _sceneRootBinder;
        //public event Action GoToMainMenuSceneRequested;

        [SerializeField] private UIGameplayRootBinder _sceneUIRootPrefab;

        //, GameplayEnterParams enterParams
        public Observable<GameplayExitParams> Run(UIRootView uIRootView, GameplayEnterParams enterParams)
        {
            var uiScene = Instantiate(_sceneUIRootPrefab);
            Debug.Log("Gameplay Scene Loaded");
            uIRootView.AttachSceneUI(uiScene.gameObject);

            var exitSceneSignalSubj = new Subject<Unit>();
            uiScene.Bind(exitSceneSignalSubj);

            Debug.Log($"Gameplay Entry Point: save file: {enterParams.SaveFileName}, level:{enterParams.LevelNumber}");
            var mainMenuExitParams = new MainMenuEnterParams("Fatality");
            var exitParams = new GameplayExitParams(mainMenuExitParams);
            var exitToMainMenuSignal = exitSceneSignalSubj.Select(_ => exitParams);

            return exitToMainMenuSignal;

        }
    }


}