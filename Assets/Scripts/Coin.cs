using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    private Collider playerCol;

    [SerializeField] private AudioSource source;

    [SerializeField] private AudioClip clip;

    [SerializeField] private float volume = 0.5f;

    private GameObject textDisplay;

    private void Awake()
    {
        textDisplay = GameObject.FindGameObjectWithTag("CoinCounter");
        var counterRef = textDisplay.GetComponent<CoinCounter>();
        source.volume = volume;
        var playerRef = GameObject.Find("Player");
        playerCol = playerRef.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == playerCol)
        {
            source.PlayOneShot(clip);

            Destroy(gameObject);

            var counterRef = textDisplay.GetComponent<CoinCounter>();

            counterRef.counter += 1;

            //GameManager.instance.currentCoinsCollected = counterRef.counter;
        }
    }
}