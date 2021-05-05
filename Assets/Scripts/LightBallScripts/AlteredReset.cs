using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlteredReset : MonoBehaviour
{
    public GameObject player;
    public GameObject ball;
    public Light ballLight;

    private Vector3 originalLocalPos;

    //private Vector3 restingPos;
    //private Quaternion restingRot;

    private Rigidbody rb;
    private Collider bcollider;

    private bool isResting = true;
    public Vector3 offset = new Vector3 (0,.3f,0);

    private Coroutine funny;

    // Start is called before the first frame update
    void Start()
    {
        originalLocalPos = gameObject.transform.localPosition;

        //restingPos = player.transform.position + offset;
        //restingRot = player.transform.rotation;

        rb = gameObject.GetComponent<Rigidbody>();
        bcollider = gameObject.GetComponent<Collider>();

        rb.isKinematic = true;
        bcollider.isTrigger = true;
    }

    private void Update()
    {
        //restingPos = player.transform.position + offset;
        //restingRot = player.transform.rotation;
    }
    public void Active()
    {
        rb.isKinematic = false;
        bcollider.isTrigger = true;
        isResting = false;
        StopAllCoroutines();
    }

    public void Resting()
    {
        isResting = true;
        ball.transform.parent = null;
        bcollider.isTrigger = false;
        ballLight.enabled = true;
        StartCoroutine("DoRest");
    }

    IEnumerator DoRest()
    {
        yield return new WaitForSeconds(10f);
        if (isResting)
        {
            ball.transform.parent = player.transform;

            gameObject.transform.localPosition = originalLocalPos;

            //gameObject.transform.position = restingPos;
            //gameObject.transform.rotation = restingRot;
            ballLight.enabled = false;

            rb.isKinematic = true;
            bcollider.isTrigger = true;
        }
    }
}

