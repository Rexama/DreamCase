using System;
using System.Collections;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

namespace _Code.LevelFolder
{
    public class LevelFolderDownloader : MonoBehaviour
    {
        private LevelFolderURLs _levelFolderUrLs;

        private void Awake()
        {
            _levelFolderUrLs = Resources.Load<LevelFolderURLs>("LevelDataURLs");
        }

        private void Start()
        {
            StartCoroutine(TryDownloadLevelFolders());
        }

        private IEnumerator TryDownloadLevelFolders()
        {
            string persistentDataPath = Application.persistentDataPath;
            int downloadedLevelCount = Directory.GetFiles(persistentDataPath).Length;
            var levelsToDownloadCount = _levelFolderUrLs.levelString.Count - _levelFolderUrLs.localStoredLevelCount;

            if (downloadedLevelCount == levelsToDownloadCount)
            {
                Debug.Log("All levels already downloaded");
                yield break;
            }

            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                Debug.Log("No internet connection, level download failed");
                yield break;
            }

            Debug.Log("Internet connection available, starting level download");

            for (int i = downloadedLevelCount+1; i < levelsToDownloadCount + 1; i++)
            {
                using (UnityWebRequest www = UnityWebRequest.Get(_levelFolderUrLs.GetLevelURL(i)))
                {
                    yield return www.SendWebRequest();

                    if (www.result != UnityWebRequest.Result.Success)
                    {
                        Debug.LogError("Error downloading file: " + www.error);
                        yield break;
                    }

                    string fileName = Path.GetFileName(_levelFolderUrLs.GetLevelURL(i));

                    string path = Path.Combine(Application.persistentDataPath, fileName);
                    File.WriteAllText(path, www.downloadHandler.text);

                    Debug.Log("File downloaded and saved: " + fileName);
                }

                AssetDatabase.Refresh();
            }
        }
    }
}