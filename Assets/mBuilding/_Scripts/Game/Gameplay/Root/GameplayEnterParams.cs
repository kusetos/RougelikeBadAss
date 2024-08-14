using System.Collections;
using UnityEngine;

namespace mBuilding.Scripts
{
    public class GameplayEnterParams : SceneEnterParams
    {
        public string SaveFileName { get; }
        public int LevelNumber { get; }
        public GameplayEnterParams(string sceneName, string saveFileName, int levelNumber) 
            : base(sceneName)
        {
            SaveFileName = saveFileName;
            LevelNumber = levelNumber;
        }
    }
}