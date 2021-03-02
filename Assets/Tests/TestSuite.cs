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
        GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GM"));
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
        yield return new WaitForSeconds(0.1f);
    }

}
