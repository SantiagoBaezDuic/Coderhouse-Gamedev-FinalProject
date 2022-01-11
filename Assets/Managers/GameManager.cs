using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] public bool dontDestroyOnLoad;

    public int currentPlayerHealth;

    public float currentHookCooldown;

    public int currentCoinsCollected = 0;

    public bool isHookOnScene;

    private void Awake()
    {
        if(instance != null)
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
    }
}
