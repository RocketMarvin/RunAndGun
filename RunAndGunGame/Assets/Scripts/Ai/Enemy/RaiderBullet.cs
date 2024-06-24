using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiderBullet : Bullet
{
    private Vector2 direction;
    public void SetDirection(Vector2 newDirection, float newSpeed)
    {
        direction = newDirection;
        speed = newSpeed;

        // Bereken de rotatie van de kogel op basis van de richting
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void Update()
    {
        // Verplaats de kogel in de aangegeven richting
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}
