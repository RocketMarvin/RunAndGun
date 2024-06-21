using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 direction;
    public float speed, ttl, damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        ttl -= Time.deltaTime;
        if (ttl < 0) Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out EnemyAi enemyAi))
        {
            enemyAi.HP -= damage;
            Destroy(gameObject);
        }
        if (collision.collider.TryGetComponent(out RaiderAI raiderAi))
        {
            raiderAi.HP -= damage;
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }

}
