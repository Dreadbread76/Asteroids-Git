using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class Game : MonoBehaviour
    {
        public int score = 0;
        public bool gameOver = false;

        [SerializeField]
        private GameObject ship;
        [SerializeField]
        private GameObject gameOverText;
        [SerializeField]
        private Text scoreText;
        [SerializeField]
        private GameObject titleText;
        [SerializeField]
        private Spawner spawner;

        private static Game instance;

        private void Start()
        {
            instance = this;
            titleText.SetActive(true);
            gameOverText.SetActive(false);
            scoreText.enabled = false;
            NewGame();
        }

        // Update is called once per frame
        public static void GameOver()
        {

            instance.gameOver = true;
            instance.spawner.StopSpawning();
            instance.ship.GetComponent<Player>().Death();
            instance.gameOverText.SetActive(true);
        }
        public void NewGame()
        {
            Debug.Log("Game Initiated");

            gameOver = false;
            titleText.SetActive(false);
            score = 0;
            scoreText.text = "Score: " + score;
            scoreText.enabled = true;
            spawner.BeginSpawning();
            ship.GetComponent<Player>().RepairShip();
            spawner.ClearAsteroids();
            gameOverText.SetActive(false);
        }
        public static void AsteroidDestroyed()
        {
            instance.score++;
            instance.scoreText.text = "Score: " + instance.score;
        }

        public Player GetPlayer()
        {
            return ship.GetComponent<Player>();
        }

        public Spawner GetSpawner()
        {
            return spawner.GetComponent<Spawner>();
        }
    }


