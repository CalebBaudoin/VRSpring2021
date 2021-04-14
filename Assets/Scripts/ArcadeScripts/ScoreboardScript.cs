using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardScript : MonoBehaviour
{
    private bool gameActive = false;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isActive()
    {
        return gameActive;
    }

    public void setActive()
    {
        gameActive = true;
    }

    public void setInactive()
    {
        gameActive = false;
    }

    public void addScore(int num)
    {

    }
}
