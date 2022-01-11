using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPlatform : MonoBehaviour
{
    private GameObject player;

    private Collider playerCol;

    public bool changeGravity = false;

    private Rigidbody rb;

    private Vector3 up;

    private Quaternion rot;

    private void OnTriggerEnter(Collider other)
    {
        if (other == playerCol)
        {
            rot = player.transform.rotation;
            changeGravity = true;
            player.transform.up = transform.up;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == playerCol)
        {
            changeGravity = false;
            player.transform.up = up;
            player.transform.rotation = rot;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCol = player.GetComponent<Collider>();
        rb = player.GetComponent<Rigidbody>();
        up = player.transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        if (changeGravity && !GameManager.instance.isHookOnScene)
        {
            rb.AddForce(0f, +9.8f, 0f, ForceMode.Acceleration);
            rb.AddForce(-transform.up * 9.8f, ForceMode.Acceleration);
        }
    }
}
