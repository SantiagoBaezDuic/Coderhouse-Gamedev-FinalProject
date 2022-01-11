using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public float hookSpeed = 25f;

    [SerializeField] private GameObject player;

    private Collider playerCol;

    private float _counter;

    private bool startCounter = false;

    private bool stopMoving = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other != playerCol)
        {
            startCounter = true;
            stopMoving = true;
        }
    }

    private void Awake()
    {
        playerCol = player.GetComponent<Collider>();
        transform.Rotate(90f, 0f, 0f, Space.Self);
        GameManager.instance.isHookOnScene = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopMoving)
        {
            transform.position += transform.up * hookSpeed * Time.deltaTime;
        }

        if (startCounter)
        {
            _counter += Time.deltaTime;
        }

        if(_counter >= 0.7f)
        {
            GameManager.instance.isHookOnScene = false;
            Destroy(gameObject);
        }
    }
}
