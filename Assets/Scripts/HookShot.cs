using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HookShot : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [SerializeField] private Transform cam;

    [SerializeField] private Transform eyes;

    [SerializeField] private GameObject hook;

    [SerializeField] private Transform hookSpawnPoint;

    [SerializeField] private float maxDist = 13f;

    [SerializeField] private float amount = 10f;

    [SerializeField] private RawImage hookSprite;

    public bool isTraveling = false;

    private float _counter;

    private float _cooldownCounter;

    private bool canShoot = true;

    [SerializeField] private float cooldown = 1f;

    private float hookSpeed;

    [SerializeField] private int hookCharges = 1;

    private RaycastHit hit;

    [SerializeField] private float pullDelay = 0.1f;

    [SerializeField] private ParticleSystem smoke;

    [SerializeField] private float forceToPull = 10f;

    private bool pulling = false;

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

                if (hit.collider.CompareTag("Hookable"))
                {
                    pulling = true;

                    Instantiate(hook, hookSpawnPoint.position, Quaternion.LookRotation(forceDir));
                    isTraveling = true;
                    canShoot = false;
                    smoke.Play();
                } 
                else
                {
                    Instantiate(hook, hookSpawnPoint.position, Quaternion.LookRotation(forceDir));
                    isTraveling = true;
                    canShoot = false;
                    smoke.Play();
                }
            }
        }

        float travelTime = hit.distance / hookSpeed;

        if (isTraveling && _counter >= travelTime + pullDelay)
        {
            Vector3 forceDir = (hit.point - rb.transform.position).normalized;

            if (!pulling)
            {
                rb.AddForce(forceDir * amount, ForceMode.Impulse);
                rb.AddForce(Vector3.up * 0.5f, ForceMode.Impulse);

                Rigidbody objectRB = hit.collider.GetComponentInParent<Rigidbody>();

                if(objectRB != null)
                {
                    if (objectRB.gameObject.isStatic != true)
                    {
                        Vector3 pullDir = (hookSpawnPoint.position - hit.point).normalized;

                        objectRB.AddForce(pullDir * forceToPull, ForceMode.Impulse);
                    }
                }
            } else
            {
                Rigidbody objectRB = hit.collider.GetComponentInParent<Rigidbody>();

                Vector3 pullDir = (hookSpawnPoint.position - hit.point).normalized;

                objectRB.AddForce(pullDir * forceToPull, ForceMode.Impulse);
            }

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
            pulling = false;
            _cooldownCounter = 0;
        }

        GameManager.instance.currentHookCooldown = _cooldownCounter;

        if (canShoot)
        {
            hookSprite.color = Color.white;
        } else
        {
            hookSprite.color = Color.red;
        }
    }
}
