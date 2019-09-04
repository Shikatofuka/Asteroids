using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy1ControllerScript : MonoBehaviour {

    public float speed = 5f;
    public float rotateSpeed = 50f;
    public bool canShoot;
    public bool canRotate;
    private bool canMove = true;
    public float boundY = -4.5f;
    public Transform attackPoint;
    public Transform attackPoint2;
    public Transform attackPoint3;
    public GameObject bulletPrefab;
    public bool has2Guns;
    public bool has3Guns;
    float life2 = 2;
    float life3 = 3;
    public static int points;


    void Start() {
        if(canRotate) {
            if(Random.Range(0, 2) > 0) {
                rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 5f);
                rotateSpeed *= -1f;
            }
        }

        if (canShoot)
            Invoke("StartShooting", Random.Range(1f, 3f));
    }

    void Update() {
        Move();
        RotateEnemy();
        if (PlayerPrefs.GetInt("HighScore") < points)
        {
            PlayerPrefs.SetInt("HighScore", points);
        }

    }

    void Move() {
        if(canMove) {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;
            transform.position = temp;

            if (temp.y < boundY)
                gameObject.SetActive(false);
        }
    }

    void RotateEnemy() {
        if (canRotate)
            transform.Rotate(new Vector3(0f, 0f, rotateSpeed + Time.deltaTime), Space.World);
    }

    void StartShooting() {
        GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, Quaternion.identity);
        bullet.GetComponent<BulletScript>().isEnemyBullet = true;

        if (has2Guns) { 
        GameObject bullet2 = Instantiate(bulletPrefab, attackPoint2.position, Quaternion.identity);
        bullet2.GetComponent<BulletScript>().isEnemyBullet = true;
        }

        if (has3Guns)
        {
            GameObject bullet2 = Instantiate(bulletPrefab, attackPoint2.position, Quaternion.identity);
            bullet2.GetComponent<BulletScript>().isEnemyBullet = true;

            GameObject bullet3 = Instantiate(bulletPrefab, attackPoint3.position, Quaternion.identity);
            bullet3.GetComponent<BulletScript>().isEnemyBullet = true;
        }


        if (canShoot)
            Invoke("StartShooting", Random.Range(1f, 3f));
    }

    void DeactivateGameObject() {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D target) {

        if (target.tag == "Bullet" || target.tag == "Player") {

            points++;

            if (gameObject.tag == "Enemy2") {
                if (life2 > 1)  {
                    life2--;
                }  else {
                    points = points + 5;
                    canMove = false;
                    if (canShoot) {
                        canShoot = false;
                        CancelInvoke("StartShooting");
                    }
                    Invoke("DeactivateGameObject", 0);
                }
            } else if (gameObject.tag == "Enemy3") {
                if (life3 > 1) {
                    life3--;
                } else {
                    points = points + 10;
                    canMove = false;
                    if (canShoot) {
                        canShoot = false;
                        CancelInvoke("StartShooting");
                    }
                    Invoke("DeactivateGameObject", 0);
                }
            } else if (gameObject.tag == "Enemy1") {
                points = points + 2;
                canMove = false;
                    if (canShoot)
                    {
                        canShoot = false;
                        CancelInvoke("StartShooting");
                    }
                    Invoke("DeactivateGameObject", 0);
                
            } else if (gameObject.tag == "ExtraLife") {
                canMove = false;
                Invoke("DeactivateGameObject", 0);
            }
        }
    }
}
