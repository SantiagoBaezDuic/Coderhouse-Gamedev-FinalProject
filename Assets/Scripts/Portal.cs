using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private GameObject player;

    private Collider playerCol;

    [SerializeField] private GameObject loadCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other == playerCol)
        {
            player.transform.position = loadCamera.transform.position;
        }
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCol = player.GetComponent<Collider>();
    }
}
