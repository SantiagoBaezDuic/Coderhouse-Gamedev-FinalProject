using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    private LineRenderer lineRenderer;

    [SerializeField] private Transform hookSpawnPoint;

    private Vector3 spawnPoint;

    private Transform hookRef = null;

    private GameObject player;

    private bool travelRef;

    private bool isDrawn = false;

    private GameObject hook;

    private Vector3[] positions;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        spawnPoint = hookSpawnPoint.position;

        if (GameManager.instance.isHookOnScene == true)
        {
            hook = GameObject.FindGameObjectWithTag("Hook");
            hookRef = hook.transform;
            positions = new Vector3[2] { spawnPoint, hookRef.position };
        }
        
        travelRef = player.GetComponent<HookShot>().isTraveling;
        if (travelRef && !isDrawn)
        {
            DrawRope(positions);
            isDrawn = true;
        }

        if(GameManager.instance.isHookOnScene == false)
        {
            lineRenderer.positionCount = 0;
            isDrawn = false;
        }

        if (isDrawn)
        {
            lineRenderer.SetPositions(positions);
        }
    }

    void DrawRope(Vector3[] vertexPositions)
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPositions(vertexPositions);
    }

}
