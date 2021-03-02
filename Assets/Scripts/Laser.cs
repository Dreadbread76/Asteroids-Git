using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private Spawner spawner;

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 5);
        if (transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Asteroid>() != null)
        {
            Game.AsteroidDestroyed();
            Destroy(gameObject);
            spawner.asteroids.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
