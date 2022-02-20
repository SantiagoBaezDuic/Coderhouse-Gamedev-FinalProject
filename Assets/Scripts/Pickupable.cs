using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    private GameObject textDisplay;

    private CoinCounter counterRef;

    private void Awake()
    {
        textDisplay = GameObject.FindGameObjectWithTag("CoinCounter");
        counterRef = textDisplay.GetComponent<CoinCounter>();
    }

    public void onPickup()
    {
        Destroy(gameObject);
    }
}
