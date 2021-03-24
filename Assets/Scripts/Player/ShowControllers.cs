using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ShowControllers : MonoBehaviour
{
    public bool showController = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var hand in Player.instance.hands)
        {
            hand.SetSkeletonRangeOfMotion(Valve.VR.EVRSkeletalMotionRange.WithController);
            if (showController)
            {
                hand.ShowController();
            }
            else
            {
                hand.HideController();
            }
        }
    }
}
