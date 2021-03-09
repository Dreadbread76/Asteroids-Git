using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

[TestFixture]
public class TestSuite
{
   
    private Game game;

    #region SetUp
    [SetUp]
    public void Setup()
    {
        GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        game = gameGameObject.GetComponent<Game>();
    }
    #endregion
    #region TearDown
    [TearDown]

    public void Teardown()
    {
        Object.Destroy(game.gameObject);
    }
    #endregion
    #region Tests
    #region Laser Kill
    [UnityTest]
    public IEnumerator LaserKill()
    {
        //Spawn laser and move it above the kill barrier
        GameObject laser = game.GetPlayer().SpawnLaser();
        laser.transform.position =  new Vector3(0f, 100f, 0f);
        yield return new WaitForSeconds(0.1f);

        //Check whether the laser no longer exists
        UnityEngine.Assertions.Assert.IsNull(laser);
    }
    #endregion
    #region Laser Spawned
    [UnityTest]
    public IEnumerator LaserSpawned()
    {
        //Spawn a laser
        GameObject laser = game.GetPlayer().SpawnLaser();
        yield return new WaitForSeconds(0.1f);

        //Check whether the laser now exists
        UnityEngine.Assertions.Assert.IsNotNull(laser);
    }
    #endregion
    #region Death Ends Game
    [UnityTest]
    public IEnumerator DeathEndsGame()
    {
        //Spawn an asteroid and move it to the player to kill the player
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        asteroid.transform.position = game.GetPlayer().transform.position;
        yield return new WaitForSeconds(0.1f);

        //Check whether the game is over
        Assert.True(game.gameOver);
    }
    #endregion
    #region Laser Cancels Asteroid
    [UnityTest]
    public IEnumerator LaserCancelsAsteroid()
    {
        //Move spawned asteroid and laser both to the same point
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        asteroid.transform.position = Vector3.zero;
        GameObject laser = game.GetPlayer().SpawnLaser();
        laser.transform.position = Vector3.zero;

        yield return new WaitForSeconds(0.1f);

        //Check whether the asteroid no longer exists
        UnityEngine.Assertions.Assert.IsNull(asteroid);
       

    }
    #endregion
    #region Asteroid Cancels Laser
    [UnityTest]
    public IEnumerator AsteroidCancelsLaser()
    {
        //Move spawned asteroid and laser both to the same point
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        asteroid.transform.position = Vector3.zero;
        GameObject laser = game.GetPlayer().SpawnLaser();
        laser.transform.position = Vector3.zero;

        yield return new WaitForSeconds(0.1f);

        //Check whether the asteroid no longer exists
        UnityEngine.Assertions.Assert.IsNull(laser);


    }

    #endregion
    #region Score Increases
    [UnityTest]
    public IEnumerator ScoreIncreases()
    {
        //Move spawned asteroid and laser both to the same point
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        asteroid.transform.position = Vector3.zero;
        GameObject laser = game.GetPlayer().SpawnLaser();
        laser.transform.position = Vector3.zero;

        yield return new WaitForSeconds(0.1f);

        //Check whether the score increases
        Assert.AreEqual(game.score, 1);


    }
    #endregion
    #endregion
}
