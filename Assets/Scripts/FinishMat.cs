using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class FinishMat : MonoBehaviour
{
    private GameObject player;

    private Collider playerCol;

    public UnityEvent<bool> onMatFinish;

    private bool startCounter = false;

    private float _totalCounter;

    [SerializeField] private Text textDisplay;

    [SerializeField] private GameObject portal;

    private int levelIndex;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == playerCol)
        {
            var counterRef = textDisplay.GetComponent<CoinCounter>();

            startCounter = false;
            Debug.Log("Ganaste!");
            Debug.Log($"Tiempo total: {_totalCounter} segundos");
            Debug.Log($"Recogiste {counterRef.counter} monedas!");
            onMatFinish?.Invoke(true);

            
            if (counterRef.counter >= GameManager.instance.coinGoals[levelIndex])
            {
                portal.SetActive(true);
            }
        }
    }

    private void Awake()
    {
        portal.SetActive(false);
        levelIndex = SceneManager.GetActiveScene().buildIndex;
        startCounter = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCol = player.GetComponent<Collider>();
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("El objetivo de monedas de este nivel es de " + GameManager.instance.coinGoals[levelIndex]);
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
