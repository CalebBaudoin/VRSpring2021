using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using Valve.VR.InteractionSystem;

public class SnapHandler : MonoBehaviour
{
    public Dropdown dd;
    private SnapTurn snap;

    // Start is called before the first frame update
    void Start()
    {
        dd = this.GetComponent<Dropdown>();
        snap = Player.instance.GetComponentInChildren<SnapTurn>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dd.value == 0)
        {
            snap.snapAngle = 15;
        }
        if (dd.value == 1)
        {
            snap.snapAngle = 45;
        }
        if (dd.value == 2)
        {
            snap.snapAngle = 90;
        }
    }
}
