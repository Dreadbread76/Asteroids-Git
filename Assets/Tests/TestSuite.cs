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
        game.GetPlayer().SpawnLaser();
        GameObject laser = GameObject.FindGameObjectWithTag("Laser");
        laser.transform.position = new Vector3(0, 11, 0);
        yield return new WaitForSeconds(0.5f);

        Assert.IsNull(laser);
    }
    [UnityTest]
    public IEnumerator LaserSpawned()
    {
        GameObject laser = game.GetPlayer().SpawnLaser();
        yield return new WaitForSeconds(0.1f);

        Assert.IsNotNull(laser);
    }
    [UnityTest]
    public IEnumerator DeathEndsGame()
    {
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        asteroid.transform.position = game.GetPlayer().transform.position;
        yield return new WaitForSeconds(0.1f);

        Assert.True(game.gameOver);
    }

}
