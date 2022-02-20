using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCoins : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnPoints = new List<GameObject>();

    [SerializeField] private GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("arranque");

        foreach (GameObject position in spawnPoints)
        {
            Instantiate(coin, position.transform.position, Quaternion.identity);
            Debug.Log("intente instanciar un " + coin + " en " + position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
