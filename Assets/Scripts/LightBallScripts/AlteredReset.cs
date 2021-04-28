using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlteredReset : MonoBehaviour
{
    public GameObject player;
    public GameObject ball;
    public Light ballLight;

    private Vector3 restingPos;
    private Quaternion restingRot;

    private Rigidbody rb;
    private Collider collider;

    private bool isResting = true;
    public Vector3 offset = new Vector3 (0,.3f,0);

    // Start is called before the first frame update
    void Start()
    {
        
        restingPos = player.transform.position + offset;
        restingRot = player.transform.rotation;

        rb = gameObject.GetComponent<Rigidbody>();
        collider = gameObject.GetComponent<Collider>();

        rb.isKinematic = true;
        collider.isTrigger = true;
    }

    private void Update()
    {
        restingPos = player.transform.position + offset;
        restingRot = player.transform.rotation;
    }
    public void Active()
    {
        
        rb.isKinematic = false;
        collider.isTrigger = false;
        isResting = false;
    }

    public void Resting()
    {
        isResting = true;
        ball.transform.parent = null;
        ballLight.enabled = true;
        StartCoroutine("DoRest");
    }

    IEnumerator DoRest()
    {
        yield return new WaitForSeconds(10f);
        if (isResting)
        {
            ball.transform.parent = player.transform;
            gameObject.transform.position = restingPos;
            gameObject.transform.rotation = restingRot;
            ballLight.enabled = false;

            rb.isKinematic = true;
            collider.isTrigger = true;
        }
    }
}

