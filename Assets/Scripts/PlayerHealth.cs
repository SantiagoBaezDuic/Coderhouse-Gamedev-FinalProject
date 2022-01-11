using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;

    public int currentHealth;

    private float _counter = 0f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if( transform.position.y < -30)
        {
            currentHealth = 0;
        }

        if(currentHealth <= 0)
        {
            _counter += Time.deltaTime;

            Debug.Log("Moriste");
            
            if(_counter >= 3f)
            {
                SceneManager.LoadScene("SampleScene");
                _counter = 0;
            }
        }

        GameManager.instance.currentPlayerHealth = currentHealth;
    }
}
