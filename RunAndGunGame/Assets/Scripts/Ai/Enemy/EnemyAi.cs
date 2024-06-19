using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{

    public float HP = 100, attackDamage = 5, shootingDamage = 20, attackRange = 3, attackTimer = 3;
    private float distance, attackTimer_Script = 3;

    public GameObject Player, enemy;

    private NavMeshAgent agent;

    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthBehaviour();
        DealDamage();
    }
    private void HealthBehaviour()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
            isDead = true;
        }
       
        if (!isDead)
        {
            agent.destination = Camera.main.transform.position;
        }
    }

    private void DealDamage()
    {

        distance = Vector3.Distance(enemy.transform.position, Player.transform.position);

        if (distance < attackRange)
        {
            attackTimer_Script -= Time.deltaTime;
            if (attackTimer_Script <= 0)
            {
                PlayerController.health -= attackDamage;
                attackTimer_Script = attackTimer;
            }
        }
    }


}
