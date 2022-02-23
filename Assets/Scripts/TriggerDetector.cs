using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerDetector : MonoBehaviour
{
    public UnityEvent<bool> onTriggerDeactivation;

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Hook"))
        {
            onTriggerDeactivation?.Invoke(true);
        }
    }
}
