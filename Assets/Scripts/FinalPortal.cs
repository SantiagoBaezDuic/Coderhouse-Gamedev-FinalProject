using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinalPortal : MonoBehaviour
{
    private GameObject player;

    private Collider playerCol;

    private int activeScene;

    [SerializeField] private TextMeshPro coins;

    [SerializeField] private TextMeshPro time;

    private void OnTriggerEnter(Collider other)
    {
        if (other == playerCol)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Application.Quit();
        }
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCol = player.GetComponent<Collider>();
        activeScene = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        coins.text = GameManager.instance.totalCoins.ToString() + " coins";

        time.text = GameManager.instance.totalTime.ToString() + " seconds";
    }
}
