using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using Valve.VR.Extras;

[System.Serializable]
public class PlayerController : MonoBehaviour
{
    public SteamVR_Action_Vector2 input = SteamVR_Input.GetAction<SteamVR_Action_Vector2>("TrackPad");
    public SteamVR_Action_Boolean teleport = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Teleport");
    public SteamVR_Action_Boolean snapTurnLeft = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("SnapTurnLeft");
    public SteamVR_Action_Boolean snapTurnRight = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("SnapTurnRight");
    public SteamVR_Action_Boolean menubtn = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Menu");

    bool anyInputs;
    private bool showMenu = false;
    private bool updateMenu = false;
    public float speed = 1;

    private CharacterController controller;
    public SteamVR_LaserPointer laserpointer;

    private Camera cam;
    public GameObject menu;

    public Vector3 gravity = new Vector3(0, 9.81f, 0);

    // Start is called before the first frame update
    void Start()
    {
        this.controller = GetComponent<CharacterController>();

        cam = this.gameObject.GetComponentInChildren<Camera>();

        laserpointer = Player.instance.gameObject.GetComponentInChildren<SteamVR_LaserPointer>();

        SummonMenu();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        anyInputs = (input.axis.x != 0) || (input.axis.y != 0) || teleport.stateDown || snapTurnLeft.stateDown || snapTurnRight.stateDown;

        Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));

        controller.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up) - gravity * Time.deltaTime);

        if (!showMenu && menubtn.stateDown && !anyInputs)
        {
            showMenu = true;
            updateMenu = true;
        }
        else if (showMenu && menubtn.stateDown && !anyInputs)
        {
            showMenu = false;
            updateMenu = true;
        }
        else if (anyInputs)
        {
            showMenu = false;
            updateMenu = true;
        }

        if (updateMenu)
        {
            SummonMenu();
            menu.transform.LookAt(cam.transform.position, Vector3.up);
            menu.transform.rotation *= Quaternion.Euler(0, 180, 0);
        }
    }

    void SummonMenu()
    {
        updateMenu = false;
        GameObject pointer = laserpointer.pointer;

        if (showMenu)
        {
            menu.transform.position = cam.transform.position + (new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z).normalized * 3f);
            
            if (pointer != null)
            {
                pointer.gameObject.SetActive(true);
            }
        }
        else
        {
            menu.transform.position = new Vector3(0, -10, 0);

            if (pointer != null)
            {
                pointer.gameObject.SetActive(false);
            }
        }
    }
}
