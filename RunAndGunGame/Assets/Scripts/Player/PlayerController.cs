using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int movementSpeed;
    public int jumpForce;
    public int health;

    float horizontalMovement;

    public bool canMove = true;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        while (canMove)
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal");
            if (horizontalMovement > 0)
            {
                print("test");
                player.transform.Translate(1, 0, 0);
            }
        }
    }
}
