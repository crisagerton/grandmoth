using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    ///This is just to check if the first scene is fully active,
    ///meaning mainly the "Di Ve" is fully shown

    public GameObject D;
    public GameObject Dswitch;
    public GameObject Iswitch;
    public GameObject gameStart;

    private bool ready;

    void Start()
    {
        ready = false;
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 Dpos = new Vector3(-3.38f, 1.15f, 0); //this is the end of the D animation, so we know it's up

        if (!Iswitch.active)
        {
            Dswitch.active = false;
        }

        if (!ready)
        {
            ready = (D.transform.position == Dpos) && !Iswitch.active;
            gameStart.SetActive(ready);
        }
    }
}
