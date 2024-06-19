using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGunFlash : MonoBehaviour
{
    public Animator animator;
    
    void PlayAnim(string animName)
    {
        animator.Play(animName);
    }

}
