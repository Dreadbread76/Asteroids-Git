using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isDead = false;
    public float speed = 5;
    public bool canShoot = true;

    [SerializeField]
    private GameObject shipSprite;
    [SerializeField]
    private GameObject laser;
    [SerializeField]
    private Transform shotSpawn;

    private float maxLeft = -8;
    private float maxRight = 8;
    

    private void Update()
    {
        if (isDead)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            ShootLaser();
        }

        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
    }

    public void ShootLaser()
    {
        StartCoroutine("Shoot");
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        GameObject laserShot = SpawnLaser();
        laserShot.transform.position = shotSpawn.position;
        yield return new WaitForSeconds(0.4f);
        canShoot = true;
    }

    public GameObject SpawnLaser()
    {
        GameObject newLaser = Instantiate(laser);
        newLaser.SetActive(true);
        return newLaser;
    }
    public void MoveLeft()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if (transform.position.x < maxLeft)
        {
            transform.position = new Vector3(maxLeft, -3.22f, 0);
        }
    }

    public void MoveRight()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        if (transform.position.x > maxRight)
        {
            transform.position = new Vector3(maxRight, -3.22f, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Game.GameOver();
           
        }
    }
    public void Death()
    {
        shipSprite.SetActive(false);
        isDead = true;
    }

    public void RepairShip()
    {
        shipSprite.SetActive(true);
        isDead = false;
    }

}
