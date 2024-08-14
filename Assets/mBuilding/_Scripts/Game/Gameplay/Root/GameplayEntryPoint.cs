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

        public Observable<GameplayExitParams> Run(UIRootView uIRootView, GameplayEnterParams enterParams)
        {
            /// setup gameplay UI
            var uiScene = Instantiate(_sceneUIRootPrefab);
            uIRootView.AttachSceneUI(uiScene.gameObject);

            /// Bind Subject to (GoToMenu)Button
            var exitSceneSignalSubj = new Subject<Unit>();
            uiScene.Bind(exitSceneSignalSubj);

            Debug.Log($"Gameplay Entry Point: save file: {enterParams.SaveFileName}, level:{enterParams.LevelNumber}");

            ///Setup menu enter Params
            var mainMenuEnterParams = new MainMenuEnterParams("Fatality");
            var exitParams = new GameplayExitParams(mainMenuEnterParams);

            /// create observer with exit params
            Observable<GameplayExitParams> exitToMainMenuSignal = exitSceneSignalSubj.Select(_ => exitParams);
            return exitToMainMenuSignal;


        }
    }


}