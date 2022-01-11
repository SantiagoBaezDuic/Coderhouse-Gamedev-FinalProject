using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookShot : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [SerializeField] private Transform cam;

    [SerializeField] private Transform eyes;

    [SerializeField] private GameObject hook;

    [SerializeField] private Transform hookSpawnPoint;

    [SerializeField] private float maxDist = 13f;

    [SerializeField] private float amount = 10f;

    public bool isTraveling = false;

    private float _counter;

    private float _cooldownCounter;

    private bool canShoot = true;

    [SerializeField] private float cooldown = 1f;

    private float hookSpeed;

    [SerializeField] private int hookCharges = 1;

    private RaycastHit hit;

    [SerializeField] private float pullDelay = 0.1f;

    private void Awake()
    {
        var hookRef = hook.GetComponent<Hook>();
        hookSpeed = hookRef.hookSpeed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
        {
            var raycastHit = Physics.Raycast(eyes.position, cam.forward, out hit, maxDist);

            if (raycastHit)
            {
                Vector3 forceDir = (hit.point - hookSpawnPoint.position).normalized;

                Instantiate(hook, hookSpawnPoint.position, Quaternion.LookRotation(forceDir));
                isTraveling = true;
                canShoot = false;
            }
        }

        float travelTime = hit.distance / hookSpeed;

        if (isTraveling && _counter >= travelTime + pullDelay)
        {
            Vector3 forceDir = (hit.point - rb.transform.position).normalized;

            rb.AddForce(forceDir * amount, ForceMode.Impulse);
            rb.AddForce(Vector3.up * 0.5f, ForceMode.Impulse);
            isTraveling = false;
            _counter = 0;
        }

        if (isTraveling)
        {
            _counter += Time.deltaTime;
        }

        if (canShoot == false)
        {
            _cooldownCounter += Time.deltaTime;
        }

        if (_cooldownCounter >= cooldown)
        {
            canShoot = true;
            _cooldownCounter = 0;
        }

        GameManager.instance.currentHookCooldown = _cooldownCounter;
    }
}
