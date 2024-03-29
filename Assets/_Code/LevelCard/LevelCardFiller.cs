﻿using System.Collections.Generic;
using _Code.LevelFolder;
using UnityEngine;

namespace _Code.LevelCard
{
    public class LevelCardFiller : MonoBehaviour
    {
        [SerializeField] private GameObject levelCardPrefab;
        private List<LevelCard> _levelCards;
        private LevelFolderURLs _levelFolderUrLs;

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
            _levelFolderUrLs = Resources.Load<LevelFolderURLs>("LevelDataURLs");
        }


        private void SetUpLevelCards()
        {
            CreateDownloadedLevelCards();

            if (!PlayerPrefs.HasKey("LatestUnlockedLevel"))
            {
                PlayerPrefs.SetInt("LatestUnlockedLevel", 1);
            }

            var latestUnlockedLevel = PlayerPrefs.GetInt("LatestUnlockedLevel", 1);

            for (var level = 1; level < _levelCards.Count + 1; level++)
            {
                var levelCard = _levelCards[level - 1];
                var levelPath = _levelFolderUrLs.GetLevelPath(level);
                var levelFileData = LevelFolderReader.ReadLevelData(levelPath);
                var isLocked = level > latestUnlockedLevel;
                var highScore = PlayerPrefs.GetInt($"HS_{level}", -1);

                var newLevelCardData = new LevelCardData(levelFileData.LevelNumber, levelFileData.MoveCount, highScore, isLocked);
                levelCard.SetUpLevelCard(newLevelCardData, levelFileData);
            }
            transform.position = -Vector3.up * _levelCards.Count;
        }

        private void CreateDownloadedLevelCards()
        {
            var downloadedLevelCount = LevelFolderReader.GetDownloadedLevelCount();
            for (var i = 0; i < downloadedLevelCount; i++)
            {
                var levelCard = Instantiate(levelCardPrefab, transform);
                _levelCards.Add(levelCard.GetComponent<LevelCard>());
            }
        }
    }
}