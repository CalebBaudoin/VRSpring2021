using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Debug.Log(rng);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Hand") && thisObject.CompareTag("Arcade")){
            
            SceneManager.LoadScene("ArcadeTest");
            
        }
        if (other.CompareTag("Hand") && thisObject.CompareTag("Labyrinth")){

            rng = Random.Range(0, 2);
            SceneManager.LoadScene("Labyrinths");
            /*
             if(rng == 0){
                SceneManager.LoadScene("FirstLabyrinth"); 
             }
             else if(rng == 1){
                SceneManager.LoadScene("RoomLab");
             }
             else if (rng == 2){
                SceneManager.LoadScene("BasicMaze");
             }
             */

        }
    }

}
