using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerScript : MonoBehaviour {

    public float speed = 5f;
    public float minX, maxX;

    [SerializeField]
    private GameObject playerBullet;

    [SerializeField]
    private Transform attackPoint;

    public float attackTimer = 0.35f;
    private float currentAttackTimer;
    bool canAttack;

    public Text healthText;
    public float health = 100;


    void Start() {
        currentAttackTimer = attackTimer;
    }


    void Update() {
        MovePlayerKeyboard();
        Attack();
        healthText.text = "" + health;
    }

    void MovePlayerKeyboard() {
        if(Input.GetAxisRaw("Horizontal") > 0f) {

            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;

            if (temp.x > maxX)
                temp.x = maxX;

            transform.position = temp;
        } else if(Input.GetAxisRaw("Horizontal") < 0f) {

            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;

            if (temp.x < minX)
                temp.x = minX;

            transform.position = temp;
        }
    }

    public void TouchLeft() {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime * 2;

        if (temp.x < minX)
            temp.x = minX;

        transform.position = temp;
    }

    public void  TouchRight() {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime * 2;

        if (temp.x > maxX)
            temp.x = maxX;

        transform.position = temp;
    }

    void Attack() {
        attackTimer += Time.deltaTime;
		if(attackTimer > currentAttackTimer) {
            canAttack = true;
        }
        if(canAttack) {
            canAttack = false;
            attackTimer = 0f;
            Instantiate(playerBullet, attackPoint.position, Quaternion.identity);
        }
    }

    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "EnemyBullet1" || target.tag == "Enemy1" || target.tag == "Enemy2" || target.tag == "Enemy3") {
            if(health > 25) {
                health = health - 25;
            } else {
                healthText.text = "0";
                Invoke("DeactivateGameObject", 0);
            }
        }

        if (target.tag == "EnemyBullet2") {
            if(health > 50) {
                health = health - 50;
            } else {
                healthText.text = "0";
                Invoke("DeactivateGameObject", 0);
            }
        }

        if (target.tag == "EnemyBullet3") {
            if(health > 75) {
                health = health - 75;
            } else {
                healthText.text = "0";
                Invoke("DeactivateGameObject", 0);
            }
        }

        if (target.tag == "ExtraLife") {
            health = health + 25;
        }

    }



}
