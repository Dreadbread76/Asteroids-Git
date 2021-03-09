using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private Spawner spawner;
    #endregion
    #region Update
    void Update()
    {
        //Move Laser up every frame and destroy it if it gets too high
        transform.Translate(Vector3.up * Time.deltaTime * 5);
        if (transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }
    #endregion
    #region OnCollisionEnter2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy itself and the asteroid on collision with an asteroid
        if (collision.gameObject.GetComponent<Asteroid>() != null)
        {
            
            Game.AsteroidDestroyed();
            Destroy(gameObject);
            spawner.asteroids.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
    #endregion
}
