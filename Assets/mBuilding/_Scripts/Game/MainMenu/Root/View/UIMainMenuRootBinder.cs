using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using R3;

public class UIMainMenuRootBinder : MonoBehaviour
{
    private Subject<Unit> _exitSceneSignalSubj;


    public void HandleGoToMainMenuButtonClicked()
    {

        _exitSceneSignalSubj?.OnNext(Unit.Default);
    }
    public void Bind(Subject<Unit> exitSceneSignal)
    {
        _exitSceneSignalSubj = exitSceneSignal;
    }
}
                                                                    