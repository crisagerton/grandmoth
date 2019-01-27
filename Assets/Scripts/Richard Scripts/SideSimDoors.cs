using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideSimDoors : MonoBehaviour
{
    public SimDoorTrigger trigger1;
    public SimDoorTrigger trigger2;

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
        if (!active && trigger1.getTriggerState() == Interactable.States.Active && trigger2.getTriggerState() == Interactable.States.Active)
        {
            door1.startMovement(Interactable.States.Active);
            door2.startMovement(Interactable.States.Active);
            active = true;
        }
    }
}
