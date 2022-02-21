using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Buoyancy : MonoBehaviour
{
    [SerializeField] private List<Transform> floatPoints = new List<Transform>();

    [SerializeField] private float underWaterDrag = 3f;

    [SerializeField] private float underWaterAngularDrag = 1f;

    [SerializeField] private float airDrag = 0f;

    [SerializeField] private float airAngularDrag = 0.05f;

    private Rigidbody m_Rigidbody;

    private int floatersUnderwater;

    private bool underwater;

    [SerializeField] private float floatingPower = 15f;

    [SerializeField] private float waterHeight = 0f;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        floatersUnderwater = 0;

        foreach(Transform floater in floatPoints)
        {
            float difference = floater.position.y - waterHeight;

            if (difference < 0)
            {
                m_Rigidbody.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(difference), floater.position, ForceMode.Force);
                floatersUnderwater += 1;
                if (!underwater)
                {
                    underwater = true;
                    SwitchState(true);
                }
            }
        }

        

        if (underwater && floatersUnderwater == 0)
        {
            underwater = false;
            SwitchState(false);
        }
    }

    private void SwitchState(bool isUnderwater)
    {
        if (isUnderwater)
        {
            m_Rigidbody.drag = underWaterDrag;
            m_Rigidbody.angularDrag = underWaterAngularDrag;
        } else
        {
            m_Rigidbody.drag = airDrag;
            m_Rigidbody.angularDrag = airAngularDrag;
        }
    }
}
