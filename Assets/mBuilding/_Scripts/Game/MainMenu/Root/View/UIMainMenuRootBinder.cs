using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using R3;
using UnityEngine.SceneManagement;
using mBuilding.Scripts;

public class UIMainMenuRootBinder : MonoBehaviour
{
    private Subject<Unit> _exitSceneSignalSubj;


    //Button
    public void HandleGoToGameplayButtonClicked()
    {
        //SceneManager.LoadScene(Scenes.GAMEPLAY);
        //Debug.Log("To Gameplay");
        StartCoroutine(BootstrapPerform.Instance.LoadAndStartGameplay("Start gameplay params FROM MENU"));

        //_exitSceneSignalSubj?.OnNext(Unit.Default);
    }
    public void Bind(Subject<Unit> exitSceneSignal)
    {
        _exitSceneSignalSubj = exitSceneSignal;
    }
}
                                                                    