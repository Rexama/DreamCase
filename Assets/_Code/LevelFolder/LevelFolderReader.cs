using System.Collections.Generic;
using System.IO;
using _Code.Game.Block;
using UnityEngine;

namespace _Code.LevelFolder
{
    internal static class LevelFolderReader
    {
        public static LevelFolderData ReadLevelData(string filePath)
        {
            LevelFolderData levelData = new LevelFolderData();

            try
            {
                using StreamReader reader = new StreamReader(filePath);
                while (reader.ReadLine() is { } line)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length != 2)
                    {
                        Debug.LogWarning("Invalid line in level data file: " + line);
                        continue;
                    }

                    string key = parts[0].Trim();
                    string value = parts[1].Trim();

                    switch (key)
                    {
                        case "level_number":
                            levelData.LevelNumber = int.Parse(value);
                            break;
                        case "grid_width":
                            levelData.GridWidth = int.Parse(value);
                            break;
                        case "grid_height":
                            levelData.GridHeight = int.Parse(value);
                            break;
                        case "move_count":
                            levelData.MoveCount = int.Parse(value);
                            break;
                        case "grid":
                            levelData.Grid = GetBlockArray(value.Split(','));
                            break;
                        default:
                            Debug.LogWarning("Unknown key in level data file: " + key);
                            break;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error reading level data file: " + ex.Message);
            }

            return levelData;
        }

        public static int GetDownloadedLevelCount()
        {
            string persistentDataPath = Application.persistentDataPath;
            return Directory.GetFiles(persistentDataPath).Length;
        }
        
        private static List<BlockType> GetBlockArray(string[] grid)
        {
            List<BlockType> blockTypes = new List<BlockType>();
            
            foreach (var color in grid)
            {
                switch (color)
                {
                    case "b":
                        blockTypes.Add(BlockType.Blue);
                        break;
                    case "g":
                        blockTypes.Add(BlockType.Green);
                        break;
                    case "r":
                        blockTypes.Add(BlockType.Red);
                        break;
                    case "y":
                        blockTypes.Add(BlockType.Yellow);
                        break;
                }
            }
            return blockTypes;
        }
    }
}