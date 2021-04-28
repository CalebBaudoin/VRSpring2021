using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using Valve.VR.InteractionSystem;

public class VigHandler : MonoBehaviour
{
    public Dropdown dd;
    private Volume vol;

    // Start is called before the first frame update
    void Start()
    {
        dd = this.GetComponent<Dropdown>();
        vol = Player.instance.GetComponentInChildren<Volume>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dd.value == 0)
        {
            vol.weight = 0;
        }
        if (dd.value == 1)
        {
            vol.weight = 0.5f;
        }
        if (dd.value == 2)
        {
            vol.weight = 0.75f;
        }
        if (dd.value == 3)
        {
            vol.weight = 1;
        }
    }
}