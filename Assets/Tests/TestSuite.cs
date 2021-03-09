using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

[TestFixture]
public class TestSuite
{

    private Game game;

    [SetUp]
    public void Setup()
    {
        GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        game = gameGameObject.GetComponent<Game>();
    }

    [TearDown]

    public void Teardown()
    {
        Object.Destroy(game.gameObject);
    }

    [UnityTest]
    public IEnumerator LaserKill()
    {
        GameObject laser = game.GetPlayer().SpawnLaser();
        laser.transform.position =  new Vector3(0f, 100f, 0f);
        yield return new WaitForSeconds(0.1f);

        //Assert.IsNull(laser);

        UnityEngine.Assertions.Assert.IsNull(laser);
    }
    [UnityTest]
    public IEnumerator LaserSpawned()
    {
        GameObject laser = game.GetPlayer().SpawnLaser();
        yield return new WaitForSeconds(0.1f);

        UnityEngine.Assertions.Assert.IsNotNull(laser);
    }
    [UnityTest]
    public IEnumerator DeathEndsGame()
    {
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        asteroid.transform.position = game.GetPlayer().transform.position;
        yield return new WaitForSeconds(0.1f);

        Assert.True(game.gameOver);
    }

    [UnityTest]
    public IEnumerator AsteroidDestroyed()
    {
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();

    }

}
