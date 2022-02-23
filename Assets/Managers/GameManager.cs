using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] public bool dontDestroyOnLoad;

    public int currentPlayerHealth;

    public int maxPlayerHealth = 100;

    public float currentHookCooldown;

    public int currentCoinsCollected = 0;

    public bool isHookOnScene;

    public int[] coinGoals;

    public int totalCoins = 0;

    public float totalTime = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
            if (dontDestroyOnLoad)
            {
                DontDestroyOnLoad(this);
            }
        }

        coinGoals = new int[10];

        coinGoals[0] = 0;
        coinGoals[1] = 20;
        coinGoals[2] = 35;
    }

    private void Start()
    {
        currentPlayerHealth = maxPlayerHealth;
    }
}
