using System;
using System.Collections.Generic;
using System.IO;
using _Code.LevelFolder;
using UnityEngine;

namespace _Code.LevelCard
{
    public class LevelCardFiller : MonoBehaviour
    {
        [SerializeField] GameObject levelCardPrefab;
        private List<LevelCard> _levelCards;
        private LevelDataURLs _levelDataURLs;

        private void Awake()
        {
            CacheComponents();
        }

        private void Start()
        {
            SetUpLevelCards();
        }

        private void CacheComponents()
        {
            _levelCards = new List<LevelCard>(GetComponentsInChildren<LevelCard>());
            _levelDataURLs = Resources.Load<LevelDataURLs>("LevelDataURLs");
        }

        private void SetUpLevelCards()
        {
            CreateDownloadedLevelCards();
            var latestUnlockedLevel = PlayerPrefs.GetInt("LatestUnlockedLevel", 1);

            for (int level = 1; level < _levelCards.Count+1; level++)
            {
                var levelCard = _levelCards[level - 1];
                var levelPath = _levelDataURLs.GetLevelPath(level);
                var levelFileData = LevelFolderReader.ReadLevelData(levelPath);
                var isLocked = level > latestUnlockedLevel;
                var highScore = PlayerPrefs.GetInt($"HS_{level}", -1);

                var newLevelCardData = new LevelCardData(levelFileData.LevelNumber, levelFileData.MoveCount, highScore, isLocked);
                
                levelCard.SetUpLevelCard(newLevelCardData);
            }
        }

        private void CreateDownloadedLevelCards()
        {
            var downloadedLevelCount = LevelFolderReader.GetDownloadedLevelCount();
            for (int i = 0; i < downloadedLevelCount; i++)
            {
                var levelCard = Instantiate(levelCardPrefab, transform);
                _levelCards.Add(levelCard.GetComponent<LevelCard>());
            }
        }
    }
}