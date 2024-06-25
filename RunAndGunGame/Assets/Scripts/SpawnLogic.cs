using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLogic : MonoBehaviour
{
    public GameObject[] checkPoints;
    public Transform player;
    private int index;
    private bool hasSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        hasSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasSpawned) SpawnBehaviour();
    }

    private void SpawnBehaviour()
    {
        index = PlayerPrefs.GetInt("checkPoint");

        if(index == 0) player.transform.position = checkPoints[0].transform.position;
        else if(index == 1) player.transform.position = checkPoints[1].transform.position;
        else if(index == 2) player.transform.position = checkPoints[2].transform.position;

        hasSpawned = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("checkPoint")) PlayerPrefs.SetInt("checkPoint", 1);
        else if (collision.gameObject.CompareTag("checkPoint2")) PlayerPrefs.SetInt("checkPoint", 2);
    }
}
