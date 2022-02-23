using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]

public class PushableCube : MonoBehaviour
{
    public UnityEvent<Vector3> onCubeActivation;

    AudioSource source;

    private void Awake()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        source.Play();
        onCubeActivation?.Invoke(Vector3.up);
    }
}
