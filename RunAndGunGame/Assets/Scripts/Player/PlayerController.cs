using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;


public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce;
    public static float health;
    public float damage;

    float horizontalMovement;

    public GameObject Player;
    public Transform transCamera, gunRotation;
    public Rigidbody2D playerRigidbody;
    public CircleCollider2D groundCheckCollider;

    public static bool canMove = true;
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        //movementSpeed *= Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            transCamera.position = new Vector3(Player.transform.position.x, transCamera.position.y, -10);

            horizontalMovement = Input.GetAxisRaw("Horizontal");
            if (horizontalMovement > 0)
            {
                gameObject.transform.Translate(movementSpeed, 0, 0);
                Player.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (horizontalMovement < 0)
            {
                gameObject.transform.Translate(movementSpeed, 0, 0);
                Player.transform.rotation = Quaternion.Euler(0, 180, 0);
            }


            ShootingLogic();
            Jump();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    private void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Death()
    {
        if(health <= 0)
        {
            //death animation en lose scene
            canMove = false;
            Debug.Log("Dead");
            Environment.Exit(0);
        }
    }

    private void ShootingLogic()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = (mousePosition - gunRotation.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        gunRotation.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (angle > 90 || angle < -90)
        {
            gunRotation.localScale = new Vector3(1, -1, 1);
        }
        else
        {
            gunRotation.localScale = new Vector3(1, 1, 1);
        }

        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                EnemyAi enemyAi = hitInfo.transform.GetComponent<EnemyAi>();
                enemyAi.HP -= damage;

                //Instantiate(enemyImpactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            }
            //else Instantiate(groundImpactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
        }
    }




}
