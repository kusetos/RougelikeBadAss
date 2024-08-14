using System.Collections;
using UnityEngine;

namespace mBuilding.Scripts
{
    public class MainMenuEnterParams
    {
        public string Results { get; }
        public MainMenuEnterParams(string results)
        {
            Results = results; 
        }
    }
}