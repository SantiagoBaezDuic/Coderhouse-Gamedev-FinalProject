using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulser : MonoBehaviour
{
    private Rigidbody playerRB;

    private float _counter;

    [SerializeField] private float jumpTime = 0.5f;

    [SerializeField] private float jumpForce = 700f;

    private bool startCounter;

    [SerializeField] private AudioSource source;

    [SerializeField] private AudioClip clip;

    private void OnCollisionEnter(Collision collision)
    {
        _counter = 0;
        startCounter = true;
    }

    private void Impulse()
    {
        _counter += Time.deltaTime;
        if (_counter >= jumpTime)
        {
            Rigidbody collision = playerRB;
            collision.AddForce(Vector3.up * jumpForce, ForceMode.Force);
            startCounter = false;
            source.PlayOneShot(clip);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        _counter = 0;
        startCounter = false;
    }

    private void Awake()
    {
        var playerRef = GameObject.Find("Player");
        playerRB = playerRef.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (startCounter)
        {
            Impulse();
        }
    }
}
