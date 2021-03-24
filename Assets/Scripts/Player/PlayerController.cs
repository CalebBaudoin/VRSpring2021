using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

[System.Serializable]
public class PlayerController : MonoBehaviour
{
    public ISteamVR_Action_Vector2 input;
    public float speed = 1;
    private CharacterController controller;

    public Vector3 gravity = new Vector3(0, 9.81f, 0);

    //Vector3 direction = new Vector3(0,0,0);

    // Start is called before the first frame update
    void Start()
    {
        this.controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));

        controller.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up) - gravity * Time.deltaTime);
    }
}
