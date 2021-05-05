using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class ShowControllers : MonoBehaviour
{
    public bool showControllersBool = false;
    public bool showHintsBool = false;

    public bool overrideBool = false;

    public Coroutine showing;

    public SteamVR_Action interactUIAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");
    public string interactUIHintText = "Interact with UI";
    public SteamVR_Action grabGripAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabGrip");
    public string grabGripText = "Grip Objects";
    public SteamVR_Action teleportAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Teleport");
    public string teleportHintText = "Snap Turn (Left/Right)" + "\n" + "Teleport (Back)";
    public SteamVR_Action touchPadAction = SteamVR_Input.GetAction<SteamVR_Action_Vector2>("TouchPad");
    public string touchPadHintText = "Walk";
    public SteamVR_Action menuAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Menu");
    public string menuHintText = "Open / Close Menu";

    private void Start()
    {
        foreach (var hand in Player.instance.hands)
        {
            hand.SetSkeletonRangeOfMotion(Valve.VR.EVRSkeletalMotionRange.WithController);
        }
    }

    private void Update()
    {
        foreach (var hand in Player.instance.hands)
        {
            hand.SetSkeletonRangeOfMotion(Valve.VR.EVRSkeletalMotionRange.WithController);
        }

        if (overrideBool)
        {
            ShowHints();
            HideControllerModels();
        }
        else if (showHintsBool)
        {
            ShowHints();
            HideControllerModels();
        }
        else if (showControllersBool)
        {
            HideHints();
            ShowControllerModels();
        }
        else
        {
            HideHints();
            HideControllerModels();

            foreach (var hand in Player.instance.hands)
            {
                hand.ShowSkeleton();
            }
        }
    }

    public void ShowControllerModels()
    {
        foreach (var hand in Player.instance.hands)
        {
            hand.ShowController();
            hand.HideSkeleton();
        }
    }

    public void HideControllerModels()
    {
        foreach (var hand in Player.instance.hands)
        {
            hand.HideController();
            hand.ShowSkeleton();
        }
    }

    public void ShowHints()
    {
        if (showing == null)
        {
            showHintsBool = true;

            foreach (var hand in Player.instance.hands)
            {
                showing = StartCoroutine(ShowTextHints(hand));
            }
        }
    }

    public void HideHints()
    {
        if (showing != null)
        {
            showHintsBool = false;
            showing = null;

            StopAllCoroutines();

            foreach (var hand in Player.instance.hands)
            {
                ControllerButtonHints.HideAllTextHints(hand);
            }
        }
    }

    private IEnumerator ShowTextHints(Hand hand)
    {
        ControllerButtonHints.HideAllTextHints(hand);

        while (true)
        {
            for (int actionIndex = 0; actionIndex < SteamVR_Input.actionsIn.Length; actionIndex++)
            {
                ISteamVR_Action_In action = SteamVR_Input.actionsIn[actionIndex];

                string displayText;
                if (action.fullPath == interactUIAction.fullPath)
                {
                    displayText = interactUIHintText;
                }
                else if (action.fullPath == grabGripAction.fullPath)
                {
                    displayText = grabGripText;
                }
                else if (action.fullPath == teleportAction.fullPath)
                {
                    displayText = teleportHintText;
                }
                else if (action.fullPath == touchPadAction.fullPath)
                {
                    displayText = touchPadHintText;
                }
                else if (action.fullPath == menuAction.fullPath)
                {
                    displayText = menuHintText;
                }
                else
                {
                    displayText = "";
                }

                if (displayText.Length > 0)
                {
                    ControllerButtonHints.HideAllTextHints(hand);
                    //StartCoroutine(BuzzController(hand));
                    ControllerButtonHints.ShowTextHint(hand, action, displayText);
                    yield return new WaitForSeconds(4.0f);
                }
            }
        }
    }

    private IEnumerator BuzzController(Hand hand)
    {
        hand.TriggerHapticPulse(10000);
        yield return new WaitForSeconds(2f);
        hand.TriggerHapticPulse(10000);
    }

}