using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleScript : MonoBehaviour
{
    Vector3 upPos = new Vector3(0, 0, 0);
    Vector3 downPos = new Vector3(0, -0.12f, 0);
    Vector3 destination = new Vector3(0, 0, 0);
    private bool bonkable = true;
    public bool down = false;

    ScoreboardScript scoreboard;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        scoreboard = GameObject.Find("MoleScoreboard").GetComponent<ScoreboardScript>();
    }

    private void FixedUpdate()
    {
        // If the mole isn't where it should be, then move towards there; it's bonkable as long as it isn't at downPos.
        if (!(Vector3.Distance(transform.localPosition, destination) <= 0.01))
        {
            Move();
            down = false;
            bonkable = true;
        }
        // If the mole is where it should be, and that place is downPos, then it's down and unbonkable.
        else if (destination == downPos)
        {
            down = true;
            bonkable = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (bonkable && Mathf.Abs(collision.relativeVelocity.magnitude) > 1)
        {
            // Hit detected!
            if (scoreboard.isActive())
            {
                scoreboard.addScore(100);
            }
            GoDown();
            bonkable = false;
        }
    }

    // Sets destination to downPos
    public void GoDown()
    {
        destination = downPos;
    }

    // Sets destination to upPos
    public void GoUp()
    {
        destination = upPos;
    }

    // Moves mole towards its destination
    private void Move()
    {
        Vector3 dir = (destination - transform.localPosition).normalized;
        transform.localPosition = transform.localPosition + dir * 3 * Time.deltaTime;
    }

    // Returns if the mole is in its down position - useful for knowing when it is dormant
    public bool isDown()
    {
        return down;
    }
}
