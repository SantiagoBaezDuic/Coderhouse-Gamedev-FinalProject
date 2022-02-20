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
        coinGoals[1] = 25;
        coinGoals[2] = 30;
    }

    private void Start()
    {
        currentPlayerHealth = maxPlayerHealth;
    }
}
