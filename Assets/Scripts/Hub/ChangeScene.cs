using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class ChangeScene : MonoBehaviour
{


    public GameObject thisObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void test()
    {
        Debug.Log("test WORKS");
    }
    private void OnTriggerEnter(Collider other)
    {
      
        if (other.CompareTag("Player") && thisObject.CompareTag("Rooms")){
           
            SceneManager.LoadScene("RoomLab");
            //SteamVR_LoadLevel.Begin("RoomLab");

        }
        if (other.CompareTag("Player") && thisObject.CompareTag("Labyrinth")){

            SceneManager.LoadScene("FirstLabyrinth");
            //SteamVR_LoadLevel.Begin("FirstLabyrinth");

        }
        if (other.CompareTag("Player") && thisObject.CompareTag("Maze")){
            //SteamVR_LoadLevel.Begin("BasicMaze");
            SceneManager.LoadScene("BasicMaze");
        }
    }

}
