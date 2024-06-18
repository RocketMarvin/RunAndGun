using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voidDeath : MonoBehaviour
{
    public GameObject Player;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Death By Void");
            Destroy(Player);
        }
    }
}
