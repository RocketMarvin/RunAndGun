using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    private Animator animator;
    public GameObject gun1, gun2;

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
                if (PlayerController.weaponID == 0)
                {
                    gun1.SetActive(true);
                    gun2.SetActive(false);
                }
                else if (PlayerController.weaponID == 1)
                {
                    gun1.SetActive(false);
                    gun2.SetActive(true);
                }
                PlayAnim("Player idle");
            }
            if (movement != 0)
            {
                if (PlayerController.weaponID == 0)
                {
                    gun1.SetActive(true);
                    gun2.SetActive(false);
                }
                else if (PlayerController.weaponID == 1)
                {
                    gun1.SetActive(false);
                    gun2.SetActive(true);
                }
                PlayAnim("Player Run");
            }
        }
    }

    void PlayAnim(string animName)
    {
        animator.Play(animName);
    }
}
