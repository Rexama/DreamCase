﻿using _Code.Tools;

namespace _Code.LevelFolder
{
    public class LevelFolderDataHolder : Singleton<LevelFolderDataHolder>
    {   
        
        
        private LevelFolderData _levelFolderData;
        public LevelFolderData LevelFolderData => _levelFolderData;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            _levelFolderData = LevelFolderReader.ReadLevelData("Assets/Resources/Levels/RM_A1");
        }

        public void SetLevelFolderData(LevelFolderData levelFolderData)
        {
            _levelFolderData = levelFolderData;
        }
    }
}