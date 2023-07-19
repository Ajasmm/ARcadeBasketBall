using System.Collections.Generic;
using UnityEngine;

namespace Game.Framework
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance
        {
            get
            {
                // if the application is already quit it return null
                if (IsApplicationQuit)
                {
                    Debug.Log("The Application is not playing");
                    return null;
                }

                // If there is no existing gamemanager Create one
                if (instance == null)
                {
                    GameObject newGameManager = new GameObject("Game Manager");
                    newGameManager.AddComponent<GameManager>();
                }
                return instance;
            }
        }
        private static GameManager instance;
        private static bool IsApplicationQuit = false;

        private Dictionary<string, object> Properties = new Dictionary<string, object>();
        public GameplayMode GameplayMode { get; private set; }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        private void OnApplicationQuit()
        {
            if (instance == this)
                IsApplicationQuit = true;
        }
        private void OnDestroy()
        {
            GameplayMode?.Stop();
        }

        public T GetProperty<T>(string name)
        {
            if (Properties.ContainsKey(name))
                return (T)Properties[name];
            else
                return default(T);
        }
        public void AddData(string name, object data)
        {
            if (!Properties.ContainsKey(name))
                Properties.Add(name, data);
            else
                Properties[name] = data;
        }
        public void SetGameplayMode(GameplayMode gameplayMode)
        {
            GameplayMode?.Stop();
            GameplayMode = gameplayMode;
            gameplayMode.Initialize();
        }
    }
}