using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlat : MonoBehaviour
{
    [SerializeField] private bool X;

    [SerializeField] private bool sign;

    private float _counter;

    private bool moved = false;

    [SerializeField] private float onTimeMove = 3f;

    [SerializeField] private float MovingTime = 9f;

    [SerializeField] private float speed = 1f;

    private Vector3 XDir = new Vector3(1, 0, 0);

    private Vector3 ZDir = new Vector3(0, 0, 1);

    private Vector3 moveDir;

    private GameObject player;

    private Collider playerCol;

    [SerializeField] private Rigidbody rb;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider == playerCol)
        {
            playerCol.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider == playerCol)
        {
            playerCol.transform.SetParent(null);
        }
    }

    private void loopMove()
    {
        _counter += Time.deltaTime;
        if (_counter >= onTimeMove)
        {
            if (moved)
            {
                
                transform.position += -moveDir * speed * Time.deltaTime;
            }
            else
            {
                transform.position += moveDir * speed * Time.deltaTime;
            }
        }

        float totalTime = onTimeMove + MovingTime / speed;

        if (_counter >= totalTime)
        {
            _counter = 0;
            moved = !moved;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        playerCol = player.GetComponent<Collider>();

        _counter = 0;

        if (X && sign)
        {
            moveDir = XDir;
        }
        else if (X && sign == false)
        {
            moveDir = -XDir;
        }
        else if (X == false && sign)
        {
            moveDir = ZDir;
        }
        else
        {
            moveDir = -ZDir;
        }
    }

    // Update is called once per frame
    void Update()
    {
        loopMove();
    }
}