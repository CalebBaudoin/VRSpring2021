using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand") && thisObject.CompareTag("Arcade")){
            Debug.Log("Fack");
            SceneManager.LoadScene("ArcadeTest");
            
        }
        if (other.CompareTag("Hand") && thisObject.CompareTag("Labyrinth")){
            Debug.Log("Fack");
            SceneManager.LoadScene("Labyrinths");

        }
    }

}
