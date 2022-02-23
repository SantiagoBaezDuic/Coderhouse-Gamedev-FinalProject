using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCoins : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnPoints = new List<GameObject>();

    [SerializeField] private GameObject coin;

    void Start()
    {
        foreach (GameObject position in spawnPoints)
        {
            Instantiate(coin, position.transform.position, Quaternion.identity);
        }
    }
}
