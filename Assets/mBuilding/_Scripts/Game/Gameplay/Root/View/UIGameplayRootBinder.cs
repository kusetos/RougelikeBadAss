using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using R3;
using mBuilding.Scripts;
using UnityEngine.SceneManagement;

public class UIGameplayRootBinder : MonoBehaviour
{
    private Subject<Unit> _exitSceneSignalSubj;

    public void HandleGoToMainMenuButtonClicked()
    {
        StartCoroutine(BootstrapPerform.Instance.LoadAndStartMainMenu("Start menu params FROM GAMEPLAY"));

        /*        SceneManager.LoadScene(Scenes.MAIN_MENU);
                Debug.Log("To menu");*/
        //_exitSceneSignalSubj?.OnNext(Unit.Default);
    }
    public void Bind(Subject<Unit> exitSceneSignalSubj)
    {
        _exitSceneSignalSubj = exitSceneSignalSubj;
    }

}
