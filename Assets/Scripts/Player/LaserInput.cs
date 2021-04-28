using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

public class LaserInput : MonoBehaviour
{
    private Hand hand;
    public SteamVR_Action_Boolean interactUIAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");

    public GameObject currentObject;
    int currentID = 0;

    // Start is called before the first frame update
    void Start()
    {
        hand = this.gameObject.GetComponent<Hand>();

        currentObject = null;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, 100f);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            int id = hit.collider.gameObject.GetInstanceID();

            if (interactUIAction.stateDown)
            {
                currentID = id;
                currentObject = hit.collider.gameObject;

                string name = currentObject.name;

                if (name == "VignetteDropdown")
                {
                    Dropdown dd = currentObject.GetComponent<Dropdown>();
                    dd.value = (dd.value + 1) % 4;
                }
                else if (name == "SnapTurnDropdown")
                {
                    Dropdown dd = currentObject.GetComponent<Dropdown>();
                    dd.value = (dd.value + 1) % 3;
                }
                else if (name == "Toggle")
                {
                    Toggle tg = currentObject.GetComponent<Toggle>();
                    tg.isOn = !tg.isOn;
                }
                else if (name == "ReturnToHubButton")
                {
                    Button bt = currentObject.GetComponent<Button>();
                    SteamVR_LoadLevel.Begin("GameHub");
                }
            }
        }
    }

    private void FixedUpdate()
    {

    }
}
