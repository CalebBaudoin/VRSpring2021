using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spoopy : MonoBehaviour
{
    float x;
    float y;
    float z;
    Quaternion spoopy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(beingSpoopy());
    }

    private void Update()
    {

       
    }
    IEnumerator beingSpoopy()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(5.0f);
            x = Random.Range(-90, 90);
            y = Random.Range(-90, 90);
            z = Random.Range(-90, 90);
            spoopy = new Quaternion(5f, x, y, z);
            this.transform.rotation = spoopy;
        }

    }
}
