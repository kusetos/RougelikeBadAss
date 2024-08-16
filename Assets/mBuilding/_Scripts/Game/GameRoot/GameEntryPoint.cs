using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using R3;
using Zenject;

namespace mBuilding.Scripts
{

    public class GameEntryPoint
    {
        private static GameEntryPoint _instance;
        private Coroutines _coroutines;
        private UIRootView _uiRoot;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void AutostartGame()
        {
            Application.targetFrameRate = 60;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;

            _instance = new GameEntryPoint();
            _instance.RunGame();
        }

        private GameEntryPoint()
        {
            _coroutines = new GameObject("[COROUTINES").AddComponent<Coroutines>();
            Object.DontDestroyOnLoad(_coroutines.gameObject);

            var prefabUIRoot = Resources.Load<UIRootView>("UIRoot");
            _uiRoot = Object.Instantiate(prefabUIRoot);
            Object.DontDestroyOnLoad(_uiRoot.gameObject);
        }

        private void RunGame()
        {
#if UNITY_EDITOR
            var sceneName = SceneManager.GetActiveScene().name;
            if(sceneName == Scenes.GAMEPLAY)
            {
                var gameplayEnterParams = new GameplayEnterParams(Scenes.GAMEPLAY, "AAA.save", 1);
                _coroutines.StartCoroutine(LoadAndStartGameplay(gameplayEnterParams));
                return;
            }
            if(sceneName == Scenes.MAIN_MENU || sceneName == Scenes.BOOT)
            {
                _coroutines.StartCoroutine(LoadAndStartMainMenu());
            }
            if (sceneName != Scenes.GAMEPLAY)
            {
                return;
            }
            
#endif
            _coroutines.StartCoroutine(LoadAndStartMainMenu());
        }

        ///GAMEPLAY LOADER
        private IEnumerator LoadAndStartGameplay(GameplayEnterParams enterParams)
        {
            /// show loading screen
            _uiRoot.ShowLoadingScreen();

            ///load scenes
            yield return LoadScene(Scenes.BOOT);
            yield return LoadScene(Scenes.GAMEPLAY);

            var sceneEntryPoint = Object.FindFirstObjectByType<GameplayEntryPoint>();

            /// startup gameplay scene UI and prepare ExitParams in Run();
            Observable<GameplayExitParams> exitToMainMenuSignal = sceneEntryPoint.Run(_uiRoot, enterParams);

            /// subscribe exitToMenu button 
            exitToMainMenuSignal.Subscribe(gameplayExitParams =>
            {
                _coroutines.StartCoroutine(LoadAndStartMainMenu(gameplayExitParams.MainMenuEnterParams));
            });

            ///hide screen
            _uiRoot.HideLoadingScreen();
        }

        /// MENU LOADER
        private IEnumerator LoadAndStartMainMenu(MainMenuEnterParams enterParams = null)
        {
            ///show loading screen
            _uiRoot.ShowLoadingScreen();

            ///load Scenes
            yield return LoadScene(Scenes.BOOT);
            yield return LoadScene(Scenes.MAIN_MENU);

            var sceneEntryPoint = Object.FindFirstObjectByType<MainMenuEntryPoint>();

            ///startup menu scene UI and prepare ExitParams in Run() 
            Observable<MainMenuExitParams> exitToGameplaySignal = sceneEntryPoint.Run(_uiRoot, enterParams);
            exitToGameplaySignal.Subscribe(mainMenuExitParams =>
            {
                var targetSceneName = mainMenuExitParams.TargetSceneEnterParams.SceneName;
                if(targetSceneName == Scenes.GAMEPLAY)
                {
                    _coroutines.StartCoroutine(LoadAndStartGameplay(mainMenuExitParams.TargetSceneEnterParams as GameplayEnterParams));
                }
            });

            ///hide loading screen
            _uiRoot.HideLoadingScreen();
        }
        private IEnumerator LoadScene(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }

    }
}