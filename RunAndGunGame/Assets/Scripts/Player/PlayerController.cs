using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;


public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce;
    public float health;

    float horizontalMovement;

    public GameObject Player;
    public Transform Camera;
    public Rigidbody2D playerRigidbody;
    public CircleCollider2D groundCheckCollider;

    public static bool canMove = true;
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        movementSpeed *= Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
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
                gameObject.transform.Translate(movementSpeed, 0, 0);
                Player.transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            Jump();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    private void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Death()
    {
        if(health <= 0)
        {
            //death animation en lose scene
            canMove = false;
        }
    }

    private void ShootingLogic()
    {
        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
    }

    

}
