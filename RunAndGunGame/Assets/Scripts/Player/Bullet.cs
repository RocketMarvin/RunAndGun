using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 direction;
    public float speed, ttl, damage;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        ttl -= Time.deltaTime;
        if (ttl < 0) Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")) Destroy(gameObject);
        if (collision.collider.TryGetComponent(out EnemyAi enemyAi))
        {
            Destroy(gameObject);
            enemyAi.HP -= damage;
        }
        if (collision.collider.TryGetComponent(out RaiderAI raiderAi))
        {
            Destroy(gameObject);
            raiderAi.HP -= damage;
        }
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }

}
