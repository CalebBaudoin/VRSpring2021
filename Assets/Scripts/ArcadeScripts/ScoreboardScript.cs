using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreboardScript : MonoBehaviour
{
    private bool gameActive = false;
    private float startTime;
    private int score;
    public TextMeshProUGUI screen;
    

    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameActive)
        {
            screen.SetText("Time: " + (Time.deltaTime - startTime) + "\n" + "Score: " + screen);
        }
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
    public void setStart(float f)
    {
        startTime = f;
    }

    public void addScore(int num)
    {
        score += num;
    }
}
