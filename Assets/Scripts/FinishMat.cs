using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishMat : MonoBehaviour
{
    private GameObject player;

    private Collider playerCol;

    [SerializeField] private GameObject controller;

    [SerializeField] private AudioSource source;

    [SerializeField] private AudioClip clip;

    private bool won;

    private bool startCounter = false;

    private float _totalCounter;

    [SerializeField] private Text textDisplay;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == playerCol)
        {
            var counterRef = textDisplay.GetComponent<CoinCounter>();

            startCounter = false;
            Debug.Log("Ganaste!");
            Debug.Log($"Tiempo total: {_totalCounter} segundos");
            Debug.Log($"Recogiste {counterRef.counter} monedas!");
            controller.SetActive(true);
            if (!won)
            {
                source.PlayOneShot(clip);
                won = true;
            }
        }
    }

    private void Awake()
    {
        startCounter = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCol = player.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startCounter)
        {
            _totalCounter += Time.deltaTime;
        }
    }
}
