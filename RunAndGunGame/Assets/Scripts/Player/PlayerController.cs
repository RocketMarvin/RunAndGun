using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce;
    public float health;

    float horizontalMovement;

    public GameObject Player;
    public Transform Camera;
    public Rigidbody2D playerRigidbody;

    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        movementSpeed *= Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        Camera.position = new Vector3(Player.transform.position.x, Camera.position.y, -10);

        horizontalMovement = Input.GetAxisRaw("Horizontal");
        if (horizontalMovement > 0)
        {
            gameObject.transform.Translate(movementSpeed, 0, 0);
            Player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (horizontalMovement < 0)
        {
            gameObject.transform.Translate(-movementSpeed, 0, 0);
            Player.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    
}
