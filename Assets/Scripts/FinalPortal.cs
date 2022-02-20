using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalPortal : MonoBehaviour
{
    private GameObject player;

    private Collider playerCol;

    private int activeScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other == playerCol)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCol = player.GetComponent<Collider>();
        activeScene = SceneManager.GetActiveScene().buildIndex;
    }
}
