using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using Valve.VR.InteractionSystem;

public class VigHandler : MonoBehaviour
{
    public Dropdown dd;
    private CharacterController cc;
    private Volume vol;

    // Start is called before the first frame update
    void Start()
    {
        dd = this.GetComponent<Dropdown>();
        cc = Player.instance.GetComponent<CharacterController>();
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
            vol.weight = 0.5f * (cc.velocity.magnitude/1);
        }
        if (dd.value == 2)
        {
            vol.weight = 0.75f * (cc.velocity.magnitude / 1);
        }
        if (dd.value == 3)
        {
            vol.weight = 1 * (cc.velocity.magnitude / 1);
        }
    }
}
