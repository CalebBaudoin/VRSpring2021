using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSecondFix : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        Player.transform.position = new Vector3 (0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
