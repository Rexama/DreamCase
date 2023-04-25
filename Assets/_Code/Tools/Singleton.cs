using UnityEngine;

namespace _Code.Tools
{
    public class Singleton<T> : MonoBehaviour
        where T : Component
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    T[] objects = FindObjectsOfType(typeof(T)) as T[];
                    if (objects is {Length: > 0})
                    {
                        _instance = objects[0];
                    }

                    if (objects is {Length: > 1})
                    {
                        Debug.LogError("There is more than one " + typeof(T).Name + " in the scene.");
                    }

                    if (_instance != null) return _instance;
                    
                    var obj = new GameObject
                    {
                        name = $"_{typeof(T).Name}"
                    };
                    _instance = obj.AddComponent<T>();
                }

                return _instance;
            }
        }
    }
}