using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

public class SummonMenu : MonoBehaviour
{
    private bool summoned = false;

    public SteamVR_LaserPointer laser;

    public SteamVR_Action_Boolean menuAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Menu");

    // Start is called before the first frame update
    void Start()
    {
        laser = Player.instance.gameObject.GetComponentInChildren<SteamVR_LaserPointer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (menuAction.stateDown)
        {
            if (!summoned)
            {
                summoned = true;

                // Summon the Menu *************************

                // Toggle the Laser Pointer
                laser.active = true;
            }
            else
            {
                summoned = false;

                // Summon the Menu *************************


                // Toggle the Laser Pointer
                laser.active = false;
            }
        }
    }
}
