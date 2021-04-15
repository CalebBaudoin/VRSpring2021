using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhackAMoleScript : MonoBehaviour
{
    List<MoleScript> ActiveMoles;
    List<MoleScript> DormantMoles;

    ScoreboardScript scoreboard;

    // Start is called before the first frame update
    void Start()
    {
        scoreboard = GameObject.Find("MoleScoreboard").GetComponent<ScoreboardScript>();

        MoleScript[] moles = this.GetComponentsInChildren<MoleScript>();

        ActiveMoles = new List<MoleScript>();
        DormantMoles = new List<MoleScript>();

        foreach (MoleScript mole in moles)
        {
            ActiveMoles.Add(mole);
        }      
    }

    // Update is called once per frame
    void Update()
    {
        bool allDormant = allMolesDormant();
        bool gamePlaying = scoreboard.isActive();

        Debug.Log(gamePlaying);

        // If the game isn't active, and all moles have been bonked down, activate game
        if (!gamePlaying && allDormant)
        {
            Debug.Log("aba");
            scoreboard.setActive();
            StartCoroutine(PlayGame());
        }
    }

    private IEnumerator PlayGame()
    {
        float startTime = Time.time; // Grab the start time

        Debug.Log("Started!");

        // Game goes on for 60s (plus an extra buzzer second)
        while (Time.time - startTime <= 60)
        {
            yield return new WaitForSeconds(1.0f); // Wait a bit of time before waking the next mole
            Debug.Log("Mole Waking!");

            int randInt = Random.Range(0, DormantMoles.Count - 1); // Generate a random index of DormantMoles to wake
            StartCoroutine(WakeMole(DormantMoles[randInt])); // Wake that mole
        }

        yield return new WaitForSeconds(2.0f); // Wait a bit (this acts as a buzzer timer like in a sport, giving the player a chance to bash any still-active moles)
        scoreboard.setInactive(); // Deactivate the scoreboard
        ActivateAllMoles(); // Wake all moles to return to pregame state

    }

    private IEnumerator WakeMole(MoleScript mole)
    {
        float timer = Random.Range(0.8f, 1.8f); // Generate a random active timer for the mole

        DormantMoles.Remove(mole); // Remove the mole from the list of dormant moles
        ActiveMoles.Add(mole); // Add it to the list of active moles

        mole.GoUp();
        yield return new WaitForSeconds(timer); // Let the mole stay up for as long as it is active

        mole.GoDown();
        yield return new WaitForSeconds(0.1f); // Give the mole a bit to return back down

        DormantMoles.Add(mole); // Add the mole back to the list of dormant moles
        ActiveMoles.Remove(mole); // Remove it from the list of active moles
    }

    // Returns true if all moles are dormant - used to start the game from resting state
    private bool allMolesDormant()
    {
        List<MoleScript> toRemove = new List<MoleScript>();

        foreach (MoleScript mole in ActiveMoles)
        {
            // If the mole is down, then it should be removed from ActiveMoles and put in DormantMoles
            if (mole.isDown())
            {
                toRemove.Add(mole);
            }
        }

        // This just moves moles from active to dormant as requested
        foreach (MoleScript mole in toRemove)
        {
            ActiveMoles.Remove(mole); // Remove the mole from the list of active moles
            DormantMoles.Add(mole); // Add the mole back to the list of dormant moles
        }

        Debug.Log(ActiveMoles.Count);

        if (ActiveMoles.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Sets all moles to the active state - useful for resetting the game to its pre-game state.
    private void ActivateAllMoles()
    {
        List<MoleScript> toAdd = new List<MoleScript>();

        foreach (MoleScript mole in DormantMoles)
        {
            mole.GoUp();

            toAdd.Add(mole);
        }

        foreach (MoleScript mole in toAdd)
        {
            DormantMoles.Remove(mole); // Remove the mole from the list of dormant moles
            ActiveMoles.Add(mole); // Add it to the list of active moles
        }
    }
}
