using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public int counter;

    [SerializeField] private Text counterDisplay;

    // Start is called before the first frame update
    void Start()
    {
        counter = GameManager.instance.currentCoinsCollected;
    }

    // Update is called once per frame
    void Update()
    {
        counterDisplay.text = $"x {counter}";
    }
}
