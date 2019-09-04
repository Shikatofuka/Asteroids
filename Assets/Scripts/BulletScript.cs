using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float speed = 5f;
    public float deactivateTimer = 3f;

    [HideInInspector]
    public bool isEnemyBullet = false;

    void Start() {
        if(isEnemyBullet) {
            speed *= -1f;
        }
        Invoke("DeactivateBullet", deactivateTimer);
    }

    void Update() {
        Move();
    }

    void Move() {
        Vector3 temp = transform.position;
        temp.y += speed * Time.deltaTime;
        transform.position = temp;
    }

    void DeactivateBullet() {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "EnemyBullet1" || target.tag == "Enemy1" || target.tag == "Enemy2" ||
            target.tag == "Enemy3" || target.tag == "ExtraLife" || target.tag == "EnemyBullet2" ||
            target.tag == "EnemyBullet3") {

            gameObject.SetActive(false);
        }
    }

}
