using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : EnemyBehaviour
{
    [SerializeField] private EnemyData data;

    private int maxHealth;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        maxHealth = data.rangedMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        bool playerHit = DetectPlayer(player);

        if (playerHit)
        {
            LookAtPlayer(player);
        }
    }
}
