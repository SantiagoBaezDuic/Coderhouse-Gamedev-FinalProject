using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private GameObject player;

    private Collider playerCol;

    [SerializeField] private GameObject loadCamera;

    [SerializeField] private bool nextLevel;

    private void OnTriggerEnter(Collider other)
    {

        if (other == playerCol)
        {
            if (nextLevel)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            } 
            else
            {
                player.transform.position = loadCamera.transform.position;
            }
        }
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCol = player.GetComponent<Collider>();
    }
}
