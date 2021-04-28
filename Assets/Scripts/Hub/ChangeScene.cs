using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class ChangeScene : MonoBehaviour
{
    int rng = 0;

    public GameObject thisObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rng = Random.Range(0, 999) % 3;
        //Debug.Log(rng);
    }

    void test()
    {
        Debug.Log("test WORKS");
    }
    private void OnTriggerEnter(Collider other)
    {
      
        if (other.CompareTag("Hands") && thisObject.CompareTag("Arcade")){
            
            //SceneManager.LoadScene("ArcadeTest");
            SteamVR_LoadLevel.Begin("ArcadeTest");
            
        }
        if (other.CompareTag("Hands") && thisObject.CompareTag("Labyrinth")){

            rng = Random.Range(0, 2);
            SceneManager.LoadScene("Labyrinths");
            //SteamVR_LoadLevel.Begin("Labyrinths");
            //SceneManager.LoadScene("RoomLab");
            //SteamVR_LoadLevel.Begin("RoomLab");
             /*if(rng == 0){
                //SteamVR_LoadLevel.Begin("FirstLabyrinth");
                SceneManager.LoadScene("FirstLabyrinth"); 
             }
             else if(rng == 1){
                //SceneManager.LoadScene("RoomLab");
                SteamVR_LoadLevel.Begin("RoomLab");
             }
             else if (rng == 2){
                //SteamVR_LoadLevel.Begin("BasicMaze");
                SceneManager.LoadScene("BasicMaze");
             }*/
             

        }
    }

}
