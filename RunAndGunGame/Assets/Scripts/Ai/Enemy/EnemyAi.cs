using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public float HP, attackDamage, attackRange, attackTimer, speed;
    private float distance, attackTimer_Script = 3;

    public int enemyID;

    public GameObject Player;
    private Animator animator;
    public CapsuleCollider2D idleCollider, runCollider;

    public bool isDead = false, chasePlayer = false, attackingPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        chasePlayer = false;
        animator = GetComponent<Animator>();
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(Player.transform.position, transform.position);
        HealthBehaviour();
        if (chasePlayer && distance > attackRange) ChaseBehaviour();
        if (chasePlayer && distance <= attackRange) AttackBehaviour();
    }

    private void HealthBehaviour()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
            isDead = true;
        }
    }

    private void ChaseBehaviour()
    {
        // Calculate the direction from the enemy to the player
        Vector3 playerPos = new Vector3(Player.transform.position.x, Player.transform.position.y, 0);
        Vector3 enemyPos = new Vector3(transform.position.x, transform.position.y, 0);
        Vector3 direction = (playerPos - enemyPos).normalized;

        // Move the enemy towards the player
        Vector3 newPosition = transform.position + direction * speed * Time.deltaTime;
        transform.position = newPosition;

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
        attackingPlayer = false;
    }

    private void AttackBehaviour()
    {
        if (distance <= attackRange)
        {
            attackTimer_Script -= Time.deltaTime;
            attackingPlayer = true;
            idleCollider.enabled = true;
            runCollider.enabled = false;
            if (attackTimer_Script <= 0)
            {
                FindObjectOfType<PlayerController>().health -= attackDamage;
                attackTimer_Script = attackTimer;
            }
        }
        else
        {
            chasePlayer = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isDead)
        {
            chasePlayer = true;
            if (attackingPlayer && enemyID == 1) PlayAnim("Enemy1 Attack");
            else if (enemyID == 1) PlayAnim("Enemy1 Run");
            if (attackingPlayer && enemyID == 2) PlayAnim("Enemy2 Attack");
            else if (enemyID == 2) PlayAnim("Enemy2 Walk");
            idleCollider.enabled = false;
            runCollider.enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isDead)
        {
            chasePlayer = true;
            if (attackingPlayer && enemyID == 1) PlayAnim("Enemy1 Attack");
            else if (enemyID == 1) PlayAnim("Enemy1 Run");
            if (attackingPlayer && enemyID == 2) PlayAnim("Enemy2 Attack");
            else if (enemyID == 2) PlayAnim("Enemy2 Walk");
            idleCollider.enabled = false;
            runCollider.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isDead)
        {
            chasePlayer = false;
            if (enemyID == 1) PlayAnim("Enemy1 Idle");
            if (enemyID == 2) PlayAnim("Enemy2 Idle");
            idleCollider.enabled = true;
            runCollider.enabled = false;
        }
    }


    void PlayAnim(string animName)
    {
        animator.Play(animName);
    }
}
