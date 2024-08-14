using System;
using System.Collections.Generic;
using UnityEngine;

namespace mBuilding.Scripts
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        //[SerializeField] private GameObject _sceneRootBinder;
        public event Action GoToMainMenuSceneRequested;

        [SerializeField] private UIGameplayRootBinder _sceneUIRootPrefab;

        public void Run(UIRootView uIRootView)
        {
            var uiScene = Instantiate(_sceneUIRootPrefab);
            Debug.Log("Gameplay Scene Loaded");
            uIRootView.AttachSceneUI(uiScene.gameObject);

            uiScene.GoToMainMenuButtonClicked += () =>
            {
                GoToMainMenuSceneRequested?.Invoke();
            };

        }
    }


}