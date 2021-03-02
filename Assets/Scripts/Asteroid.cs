using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    float speed = 1f;
    float killBarrier = -5f;

    [SerializeField]
    private Spawner spawner;

    // Start is called before the first frame update
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        if (transform.position.y < killBarrier)
        {
            
            Destroy(gameObject);

        }
    }

}
