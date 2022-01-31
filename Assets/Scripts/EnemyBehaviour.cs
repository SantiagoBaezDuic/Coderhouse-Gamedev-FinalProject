using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private GameObject player;

    private float distanceToPlayer;

    private Vector3 playerDir;

    private Collider playerCol;

    protected bool DetectPlayer(GameObject player)
    {
        bool playerHit = false;

        RaycastHit hit;

        Transform playerTransform = player.GetComponent<Transform>();

        playerDir = playerTransform.position - transform.position;

        Physics.Raycast(transform.position, playerDir, out hit, 15f);

        if (hit.collider == playerCol)
        {
            playerHit = true;
        }

        return playerHit;
    }

    protected void LookAtPlayer(GameObject player)
    {
        Transform playerTransform = player.GetComponent<Transform>();

        playerDir = playerTransform.position - transform.position;

        transform.forward = playerDir.normalized;
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCol = player.GetComponent<Collider>();
    }

    private void Update()
    {
        if(distanceToPlayer <= 15f)
        {
            DetectPlayer(player);
        }
    }
}
