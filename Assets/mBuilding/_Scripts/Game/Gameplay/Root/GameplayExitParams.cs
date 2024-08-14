using System.Collections;
using UnityEngine;

namespace mBuilding.Scripts
{
    public class GameplayExitParams
    {
        public MainMenuEnterParams MainMenuEnterParams { get; }
         public GameplayExitParams(MainMenuEnterParams mainMenuEnterParams)
        {
            MainMenuEnterParams = mainMenuEnterParams;
        }
    }
}