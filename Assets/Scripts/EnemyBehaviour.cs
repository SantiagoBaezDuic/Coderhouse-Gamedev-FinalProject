using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private GameObject player;

    private float distanceToPlayer;

    private Vector3 playerDir;

    private Transform playerTransform;

    private Collider playerCol;

    private void DetectPlayer()
    {
        RaycastHit hit;

        playerDir = playerTransform.position - transform.position;

        Physics.Raycast(transform.position, playerDir, out hit, 15f);

        if (hit.collider == playerCol)
        {
        }
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        playerCol = player.GetComponent<Collider>();
    }

    private void Update()
    {
        if(distanceToPlayer <= 15f)
        {
            DetectPlayer();
        }
    }
}
