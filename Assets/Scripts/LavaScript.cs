using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    [SerializeField] private float lavaTick = 0.5f;

    [SerializeField] private Collider player;

    [SerializeField] private AudioClip hurtSound;

    private float _counter;

    [SerializeField] private int Damage = 10;

    [SerializeField] private GameObject lavaMaskVFX;

    private void Awake()
    {
        lavaMaskVFX.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        _counter = 0;
        if(other == player)
        {
            lavaMaskVFX.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _counter = 0;
        lavaMaskVFX.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        AudioSource source = player.GetComponent<AudioSource>();

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
                source.PlayOneShot(hurtSound);
            }
       
            _counter = 0;
        }
    }
}
