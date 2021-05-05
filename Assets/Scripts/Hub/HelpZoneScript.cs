using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;


public class HelpZoneScript : MonoBehaviour
{
    public GameObject player;
    private ShowControllers sc;
    private float radius = 2.5f;

    private bool showing = true;

    // Start is called before the first frame update
    void Awake()
    {
        player = Player.instance.gameObject;
        sc = player.GetComponent<ShowControllers>();
    }

    private void Update()
    {
        {
            if (showing)
            {
                sc.showHintsBool = true;
            }
            else
            {
                sc.showHintsBool = false;
            }
        }
    }

    void FixedUpdate()
    {
        bool inRange = Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.z), new Vector2(player.transform.position.x, player.transform.position.z)) <= radius;

        if (inRange && !showing)
        {
            showing = true;
        }
        else if (!inRange)
        {
            showing = false;
        }
    }
}
