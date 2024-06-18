using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    private Animator animator;
    public GameObject gun;

    float movement;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (PlayerController.canMove)
        {
            movement = Input.GetAxisRaw("Horizontal");
            if (movement == 0)
            {
                gun.SetActive(true);
                animator.SetBool("Running", false);
                PlayAnim("Player idle");
            }
            if (movement != 0)
            {
                gun.SetActive(false);
                animator.SetBool("Running", true);
                PlayAnim("Player Run");
            }
        }
    }

    void PlayAnim(string animName)
    {
        animator.Play(animName);
    }
}
