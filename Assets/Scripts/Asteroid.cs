using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    #region Variables
    float speed = 1f;
    float killBarrier = -5f;

    [SerializeField]
    private Spawner spawner;
    #endregion
    #region Update
    void Update()
    {
        //Move asteroid down every frame
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        //Kill asteroid if it wanders too far
        if (transform.position.y < killBarrier)
        {
            
            Destroy(gameObject);

        }
    }
    #endregion
}
