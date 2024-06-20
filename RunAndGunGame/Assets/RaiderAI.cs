using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiderAI : MonoBehaviour
{
    public float HP = 100, attackDamage = 5, shootingDamage = 20, attackRange = 3, attackTimer = 3, bulletSpeed = 4;
    private float distance, attackTimer_Script = 3;

    public GameObject Player;
    private Animator animator;

    private bool isDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthBehaviour();
    }
    private void HealthBehaviour()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
            isDead = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 playerPos = Player.transform.position;
    }
}
