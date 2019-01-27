using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMultiTriggerDoors : MonoBehaviour
{
    public List<MultiDoorTriggers> doorTriggers = new List<MultiDoorTriggers>();

    public SideDoorAnimation door1;
    public SideDoorAnimation door2;

    private bool active = false;

    public void Awake()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!active && triggerCheck())
        {
            door1.startMovement(Interactable.States.Active);
            door2.startMovement(Interactable.States.Active);
            active = true;
        }
    }

    public bool triggerCheck()
    {
        foreach (MultiDoorTriggers doorTrigger in doorTriggers)
        {
            if (doorTrigger.getCurrentState() != Interactable.States.Active)
                return false;
        }

        return true;
    }
}
