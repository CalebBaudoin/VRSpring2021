using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class SimpleGrab : MonoBehaviour
{
	private Interactable interactable;

    // Start is called before the first frame update
    void Start()
    {
		interactable = GetComponent<Interactable>();
    }

	private void OnHandHoverBegin(Hand hand)
	{
		hand.ShowGrabHint();
	}


	//-------------------------------------------------
	private void OnHandHoverEnd(Hand hand)
	{
		hand.HideGrabHint();
	}

	private void HandHoverUpdate(Hand hand)
    {
		GrabTypes grabtype = hand.GetGrabStarting();

		bool isGrabEnding = hand.IsGrabEnding(gameObject);

		if(interactable.attachedToHand == null && grabtype != GrabTypes.None)
        {
			hand.AttachObject(gameObject, grabtype);
			hand.HoverLock(interactable);
			hand.HideGrabHint();
		}

		else if (isGrabEnding)
        {
			hand.DetachObject(gameObject);
			hand.HoverUnlock(interactable);
        }
	}
}
