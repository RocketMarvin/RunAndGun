using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiderAI : MonoBehaviour
{
    public float HP = 50, shootingDamage = 20, attackRange = 20, attackTimer = 3, bulletSpeed = 4;
    private float attackTimer_Script = 3;

    public GameObject Player, firepoint, bullet;
    private Animator animator;

    public bool inRange = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthBehaviour();

        // Check if the player is on the left or right to flip the enemy
        if (Player.transform.position.x < transform.position.x)
        {
            // Player is to the left, flip the enemy
            transform.localScale = new Vector3(1, 1, 1); // Flip on the x-axis
        }
        else
        {
            // Player is to the right, normal scale
            transform.localScale = new Vector3(-1, 1, 1); // Normal scale
        }

        Shoot();
    }
    private void HealthBehaviour()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) inRange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) inRange = false;
    }

    private void Shoot()
    {
        if (inRange)
        {
            // Bereken de richting naar de speler
            Vector2 playerPos = Player.transform.position;
            Vector2 firepointPos = firepoint.transform.position;
            Vector2 direction = (playerPos - firepointPos).normalized;

            attackTimer_Script -= Time.deltaTime;

            if (attackTimer_Script <= 0)
            {
                // Instantieer de kogel
                GameObject bulletInstance = Instantiate(bullet, firepointPos, Quaternion.identity);
                // Stel de richting van de kogel in
                bulletInstance.GetComponent<RaiderBullet>().SetDirection(direction, bulletSpeed);

                attackTimer_Script = attackTimer;
            }
        }

    }
}
