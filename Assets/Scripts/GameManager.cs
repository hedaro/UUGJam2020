using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace MultiGameJam
{
    public enum GameState
    {
        Idle,
        Loading,
        Paused,
        Playing,
        GameOver
    }

    public class GameManager : MonoBehaviour
    {
        protected static GameManager manager;

        protected NavigationData navigationData;
        protected List<int> playList;
        protected GameObject loadOverlay;
        protected GameState gameState;
        protected UnityAction GameOver, NextGame, PointsEarned;

        [HideInInspector]
        public int currentGame;
        [HideInInspector]
        public int lives;
        protected float gameTime;
        protected int score;

        public static int CurrentGame
        {
            get
            {
                return manager.currentGame;
            }
        }

        public static float RemainingTime
        {
            get
            {
                return manager.navigationData.timePerGame - manager.gameTime;
            }
        }

        protected static void CreateInstance()
        {
            GameObject navigator = new GameObject("GameManager");
            manager = navigator.AddComponent<GameManager>();
            manager.Init(Resources.Load<NavigationData>("Navigation"));
            DontDestroyOnLoad(manager);
        }

        public static void StartGame()
        {
            if (!manager)
            {
                CreateInstance();
            }

            manager.lives = 3;
            manager.SetPlayList();
            manager.StartNextGame();
        }

        public static void GameLoaded()
        {
            Debug.Log("<color=orange>Game Started!</color>");
            if (!manager)
                return;

            manager.gameTime = 0;
            manager.SetLoadScreen(false);
            manager.gameState = GameState.Playing;
        }

        public static void AddPoints(int points)
        {
            Debug.Log("You got <color=yellow><b>" + points + " points</b></color>");
            if (!manager)
                return;
            manager.score += points;
        }

        public static void DamagePlayer()
        {
            Debug.Log("<color=red>Player damaged</color>");
            if (!manager)
                return;

            if (manager.gameState != GameState.Playing)
                return;
            manager.lives--;

            if (manager.lives <= 0)
            {
                manager.gameState = GameState.GameOver;
                Debug.Log("<b>GameOver score: <color=blue>" + manager.score + "</color></b>");
                SceneManager.LoadScene(0);
            }
        }

        private void Init(NavigationData navigationData)
        {
            this.navigationData = navigationData;
            loadOverlay = Instantiate(navigationData.loadLayout);
            DontDestroyOnLoad(manager.loadOverlay);
        }

        protected void SetLoadScreen(bool show)
        {
            loadOverlay.SetActive(show);
        }

        protected void SetPlayList()
        {
            currentGame = -1;
            playList = new List<int>();
            playList = navigationData.gameCollection.games.Select(a => a.id).OrderBy(v => UnityEngine.Random.value).ToList();
        }

        private void StartNextGame()
        {
            manager.SetLoadScreen(true);
            currentGame++;
            if (currentGame >= playList.Count)
            {
                SetPlayList();
                currentGame = 0;
            }
            Debug.Log("Start loading next game:  <color=green><b>" + navigationData.gameCollection.games[playList[currentGame]].name + "</b></color>");
            manager.gameState = GameState.Loading;
            SceneManager.LoadSceneAsync(navigationData.gameCollection.games[playList[currentGame]].baseScene);
        }

        public void CleanUp()
        {
            Destroy(loadOverlay);
            Destroy(manager.gameObject);
        }

        private void Update()
        {
            if (gameState == GameState.Playing)
            {
                gameTime += Time.deltaTime;

                if (gameTime > navigationData.timePerGame)
                {
                    StartNextGame();
                }
            }
        }
    }
}
