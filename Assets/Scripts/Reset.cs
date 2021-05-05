using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Reset : MonoBehaviour
{
    private Vector3 restingPos;
    private Quaternion restingRot;

    private Rigidbody rb;

    private bool isResting = true;

    // Start is called before the first frame update
    void Start()
    {
        restingPos = this.transform.position;
        restingRot = this.transform.rotation;

        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void Active()
    {
        rb.isKinematic = false;
        isResting = false;
    }

    public void Resting()
    {
        isResting = true;
        StartCoroutine("DoRest");
    }

    IEnumerator DoRest()
    {
        yield return new WaitForSeconds(.02f);
        if (isResting)
        {
            gameObject.transform.position = restingPos;
            gameObject.transform.rotation = restingRot;

            rb.isKinematic = true;
        }
    }
}
