using mBuilding.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public class BootstrapPerform
{
    private Coroutines _coroutines;

    private static BootstrapPerform _instance = null;
    public static BootstrapPerform Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new BootstrapPerform();
            }
            return _instance;
        }
    }

    private BootstrapPerform()
    {
        _coroutines = new GameObject("[COROUTINES").AddComponent<Coroutines>();
        Object.DontDestroyOnLoad(_coroutines.gameObject);
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void AutostartGame()
    {
        Debug.Log("Perform Boots");
        Application.targetFrameRate = 200;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        Instance.RunGame();
    }

    private void RunGame()
    {
#if UNITY_EDITOR
        var sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == Scenes.GAMEPLAY)
        {
            //var gameplayEnterParams = new GameplayEnterParams(Scenes.GAMEPLAY, "AAA.save", 1);
            _coroutines.StartCoroutine(LoadAndStartGameplay("gameplay start from Editor"));
            //S
            return;
        }
        if (sceneName == Scenes.MAIN_MENU || sceneName == Scenes.BOOT)
        {
           _coroutines.StartCoroutine(LoadAndStartMainMenu("Menu start from editor"));
        }
        if (sceneName != Scenes.GAMEPLAY)
        {
            return;
        }

#endif
        _coroutines.StartCoroutine(LoadAndStartMainMenu("Menu start in game"));
    }

    public IEnumerator LoadAndStartGameplay(string s)
    {
        //show loading screen


        Debug.Log(s);
        //yield return LoadScene(Scenes.BOOT);
        yield return LoadScene(Scenes.GAMEPLAY);

        //Load data for menu

        //hide loading
    }

    public IEnumerator LoadAndStartMainMenu(string s)
    {   
        //show loading screen

        Debug.Log(s);
        //yield return LoadScene(Scenes.BOOT);
        yield return LoadScene(Scenes.MAIN_MENU);

        //Load data for menu

        //hide loading

    }

    private IEnumerator LoadScene(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName);
    }
}
