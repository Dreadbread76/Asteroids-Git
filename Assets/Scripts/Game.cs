using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Game : MonoBehaviour
{
    #region Variables
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

    #endregion
    #region Start
    //Enable relevant methods and enitities on startup
    private void Start()
        {
            instance = this;
            titleText.SetActive(true);
            gameOverText.SetActive(false);
            scoreText.enabled = false;
            NewGame();
        }
    #endregion
    #region Game Over
    //Enable game over screen and disable player and spawners
    public static void GameOver()
        {

            instance.gameOver = true;
            instance.spawner.StopSpawning();
            instance.ship.GetComponent<Player>().Death();
            instance.gameOverText.SetActive(true);
        }
    #endregion
    #region New Game
    //Start a fresh new game
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
    #endregion
    #region Asteroid Destroyed
    //Increase score when an asteroid is destroyed
    public static void AsteroidDestroyed()
        {
            instance.score++;
            instance.scoreText.text = "Score: " + instance.score;
        }
    #endregion
    #region Get Player
    //Find the script on the player's ship
    public Player GetPlayer()
        {
            return ship.GetComponent<Player>();
        }
    #endregion
    #region Get Spawner
    //Find the spawner script on the spawner entity
    public Spawner GetSpawner()
    {
         return spawner.GetComponent<Spawner>();
    }
    #endregion
}



