using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth;

    [SerializeField] private GameObject deathUI;

    public int currentHealth;

    private float _counter = 0f;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = GameManager.instance.maxPlayerHealth;
        currentHealth = maxHealth;
        deathUI.SetActive(false);
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
            deathUI.SetActive(true);
            Time.timeScale = 0.2f;
            
            if(_counter >= 1f)
            {
                int activeScene = SceneManager.GetActiveScene().buildIndex;

                deathUI.SetActive(false);
                SceneManager.LoadScene(activeScene);
                Time.timeScale = 1f;
                _counter = 0;
            }
        }

        GameManager.instance.currentPlayerHealth = currentHealth;
    }
}
