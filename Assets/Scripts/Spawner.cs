using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject asteroid;

    public List<GameObject> asteroids = new List<GameObject>();

    public void BeginSpawning()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(0.4f);

        SpawnAsteroid();
        StartCoroutine("Spawn");
    }
    public GameObject SpawnAsteroid()
    {
       
        GameObject spawnedAsteroid;
        spawnedAsteroid = Instantiate(asteroid);
        

        asteroid.SetActive(true);
        float xPos = Random.Range(-8.0f, 8.0f);

        // Spawn asteroid just above top of screen at a random point along x-axis
        asteroid.transform.position = new Vector3(xPos, 7.35f, 0);

        asteroids.Add(spawnedAsteroid);

        

        return spawnedAsteroid;
    }
    public void ClearAsteroids()
    {
        foreach (GameObject spawnedAsteroid in asteroids)
        {
            Destroy(spawnedAsteroid);
        }

        asteroids.Clear();
    }

    public void StopSpawning()
    {
        StopCoroutine("Spawn");
    }
}
