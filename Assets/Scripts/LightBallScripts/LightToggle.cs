using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightToggle : MonoBehaviour
{

    public GameObject ball;
    public Light plight;
    // Start is called before the first frame update
    void Start()
    {
        plight.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        plight.enabled = true;
    }
}
