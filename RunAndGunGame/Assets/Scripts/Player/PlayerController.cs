using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float jumpForce, health, damage, speed;
    float horizontalMovement;

    public static int weaponID = 0;

    public GameObject Player, bullet ,g1FirePoint1, g1FirePoint2, g1FirePoint3, gun1, gun2, g2FirePoint;
    public Transform transCamera, gunRotation;
    public Rigidbody2D playerRigidbody;
    public AudioSource gunShot;
    public Image barHP;


    public static bool canMove = true;
    private bool isGrounded = false, moving = false;

    // Start is called before the first frame update
    void Start()
    {
        canMove = false;
        weaponID = 0;
    }

    // Update is called once per frame
    void Update()
    {
        barHP.fillAmount = health / 50;
        if (canMove)
        {
            transCamera.position = new Vector3(Player.transform.position.x, transCamera.position.y, -10);

            float movementSpeed = speed * Time.deltaTime;

            horizontalMovement = Input.GetAxisRaw("Horizontal");
            if (horizontalMovement > 0)
            {
                moving = true;
                gameObject.transform.Translate(movementSpeed, 0, 0);
                Player.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (horizontalMovement < 0)
            {
                moving = true;
                gameObject.transform.Translate(movementSpeed, 0, 0);
                Player.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else moving = false;

            if (!moving) ShootingLogic();
            Jump();
            WeaponSwitch();
        }

        if (health <= 0) Death();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) isGrounded = false;
    }
    private void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) playerRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Death()
    {
        if(health <= 0)
        {
            //death animation en lose scene
            canMove = false;
            Debug.Log("Dead");
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

        if (Input.GetMouseButtonDown(0))
        {
            gunShot.Play();
            if (weaponID == 0)
            {
                GameObject bulletObj = Instantiate(bullet, g1FirePoint1.transform.position, g1FirePoint1.transform.rotation);
                bulletObj = Instantiate(bullet, g1FirePoint2.transform.position, g1FirePoint2.transform.rotation);
                bulletObj = Instantiate(bullet, g1FirePoint3.transform.position, g1FirePoint3.transform.rotation);
                bulletObj.GetComponent<Bullet>().damage = damage;
            }
            else
            {
                GameObject bulletObj = Instantiate(bullet, g2FirePoint.transform.position, g2FirePoint.transform.rotation);
                bulletObj.GetComponent<Bullet>().damage = damage;
            }
        }
    }

    public void WeaponSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (weaponID == 1)
            {
                gun1.SetActive(false);
                gun2.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Q)) weaponID = 0;
            }
            else
            {
                gun1.SetActive(true);
                gun2.SetActive(false);
                weaponID++;
            }
        }
    }


}
