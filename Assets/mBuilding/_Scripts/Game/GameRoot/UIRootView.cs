using System.Collections;
using UnityEngine;

namespace mBuilding.Scripts
{
    public class UIRootView : MonoBehaviour
    {
        [SerializeField] private GameObject _loadingScreen;
        [SerializeField] private Transform uiSceneContainer;

        private void Awake()
        {
            HideLoadingScreen();
        }
        public void ShowLoadingScreen()
        {
            _loadingScreen.SetActive(true);
        }
        public void HideLoadingScreen()
        {
            _loadingScreen.SetActive(false);
        }
        public void AttachSceneUI(GameObject sceneUI)
        {
            ClearSceneUI();
            sceneUI.transform.SetParent(uiSceneContainer, false);
        }
        public void ClearSceneUI()
        {
            var childCount = uiSceneContainer.childCount;
            for(int i = 0; i < childCount; i++)
            {
                Destroy(uiSceneContainer.GetChild(i).gameObject);
            }
        }
    }
}