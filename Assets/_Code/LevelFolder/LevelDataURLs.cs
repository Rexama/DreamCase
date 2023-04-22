using System.Collections.Generic;
using UnityEngine;

namespace _Code.LevelFolder
{
    [CreateAssetMenu(fileName = "LevelDataURLs", menuName = "Data/LevelDataURLs", order = 0)]
    public class LevelDataURLs : ScriptableObject
    {
        public int localStoredLevelCount;
        public string coreURL;
        public List<string> levelString;
        
        public string GetLevelURL(int levelNumber)
        {
            return coreURL + levelString[levelNumber + localStoredLevelCount - 1];
        }
        
        public string GetLevelPath(int level)
        {
            if(level <= 10)
            {
                return Application.dataPath + "/Resources/Levels/RM_"+levelString[level - 1];
            }
            else
            {
                return Application.persistentDataPath + "/RM_" + levelString[level - 1];
            }
        }
    }
}