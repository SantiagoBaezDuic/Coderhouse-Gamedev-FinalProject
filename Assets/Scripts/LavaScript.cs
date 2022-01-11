using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    [SerializeField] private float lavaTick = 0.5f;

    [SerializeField] private Collider player;

    private float _counter;

    [SerializeField] private int Damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        _counter = 0;
    }

    private void OnTriggerExit(Collider other)
    {
        _counter = 0;
    }

    private void OnTriggerStay(Collider other)
    {
        _counter += Time.deltaTime;
        if (other == player && _counter >= lavaTick)
        {
            var playerRef = player.GetComponent<PlayerHealth>();

            if(playerRef.currentHealth <= 0)
            {
                playerRef.currentHealth = 0;
            } else
            {
                playerRef.currentHealth -= Damage;
            }
       
            _counter = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
