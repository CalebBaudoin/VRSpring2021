using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confetti : MonoBehaviour
{
    public ParticleSystem confetti;
    public GameObject jankySolution;
    
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        
        Debug.Log("Pls wrk.");
        confetti.Play();
    }
}
