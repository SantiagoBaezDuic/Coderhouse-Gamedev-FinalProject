using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWaterVFX : MonoBehaviour
{
    [SerializeField] private GameObject playerEyes;

    [SerializeField] private GameObject postProcess;

    private void Awake()
    {
        postProcess.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerEyes.transform.position.y < 0)
        {
            postProcess.SetActive(true);
        } else
        {
            postProcess.SetActive(false);
        }
    }
}
