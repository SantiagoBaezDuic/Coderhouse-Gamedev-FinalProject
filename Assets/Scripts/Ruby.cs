using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby : Pickupable
{
    [SerializeField] private ItemData data;

    private Collider playerCol;

    private AudioSource source;

    [SerializeField] private float volume = 0.5f;

    private void Awake()
    {
        source = GetComponentInParent<AudioSource>();
        source.volume = volume;
        var playerRef = GameObject.Find("Player");
        playerCol = playerRef.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == playerCol)
        {
            onPickup(source, data);
        }
    }
}
