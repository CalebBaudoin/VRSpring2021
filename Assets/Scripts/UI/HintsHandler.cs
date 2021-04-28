using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;
using UnityEngine.SceneManagement;

public class HintsHandler : MonoBehaviour
{
    public Toggle tg;
    private ShowControllers showCons;

    // Start is called before the first frame update
    void Start()
    {
        tg = this.GetComponent<Toggle>();
        showCons = Player.instance.GetComponent<ShowControllers>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tg.isOn)
        {
            showCons.overrideBool = true;
            showCons.ShowHints();
        }
        else
        {
            showCons.overrideBool = false;
            showCons.HideHints();
        }
    }
}
