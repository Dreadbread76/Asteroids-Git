using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Variables
    public GameObject asteroid;

    public List<GameObject> asteroids = new List<GameObject>();
    #endregion
    #region Begin Spawning
    //Start Spawning Sequence
    public void BeginSpawning()
    {
        Debug.Log("Spawning initiated");
        StartCoroutine("Spawn");
    }
    #endregion
    #region Spawn
    //Spawn Loop
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(0.4f);

        SpawnAsteroid();
        StartCoroutine("Spawn");
    }
    #endregion
    #region Spawn Asteroid
    //Spawn in an Asteroid
    public GameObject SpawnAsteroid()
    {
       
        GameObject spawnedAsteroid;
        spawnedAsteroid = Instantiate(asteroid);
        

        asteroid.SetActive(true);
        //Random Spawn Position
        float xPos = Random.Range(-8.0f, 8.0f);

        // Spawn asteroid just above top of screen at a random point along x-axis
        asteroid.transform.position = new Vector3(xPos, 7.5f, 0);

        asteroids.Add(spawnedAsteroid);

        

        return spawnedAsteroid;
    }
    #endregion
    #region Clear Asteroids
    //Remove all asteroids
    public void ClearAsteroids()
    {
        //Get every asteroid and remove them
        foreach (GameObject spawnedAsteroid in asteroids)
        {
            DestroyImmediate(spawnedAsteroid, true);
        }

        asteroids.Clear();
    }
    #endregion
    #region Stop Spawning
    //Stop Spawning Loop
    public void StopSpawning()
    {
        StopCoroutine("Spawn");
    }
    #endregion
}
