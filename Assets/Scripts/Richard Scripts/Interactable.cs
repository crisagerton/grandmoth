using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [Header("Characters Interactable With")]
    public bool mothInteractable = false;
    public bool lightInteractable = false;

    protected bool active = false;

    // Checks if specified objects are colliding
    private bool mothColliding = false;
    private bool lightColliding = false;
    
    public virtual void Awake()
    {
        active = false;
        mothColliding = false;
        lightColliding = false;
    }

    public virtual void Update()
    {
        // TEMP INPUT KEY
        if (mothCollidingCheck() && Input.GetAxisRaw("MothInteract") != 0)
            mothTriggerEffect();

        if (lightCollidingCheck() && Input.GetAxisRaw("LightInteract") != 0)
            lightTriggerEffect();
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (mothTriggerCheck(collision))
            mothColliding = true;

        if (lightTriggerCheck(collision))
            lightColliding = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Moth")
            mothColliding = false;

        if (collision.tag == "Light")
            lightColliding = false;
    }

    // Abstract methods for the trigger effects;
    public abstract void mothTriggerEffect();

    public abstract void lightTriggerEffect();

    #region Colliding Condition Check
    private bool mothCollidingCheck()
    {
        return (mothColliding && !active);
    }

    private bool lightCollidingCheck()
    {
        return (lightColliding && !active);
    }
    #endregion Colliding Condition Check

    #region Trigger Condition Checks
    protected bool mothTriggerCheck(Collider2D collision)
    {
        return (mothInteractable && !active && collision.tag == "Moth");
    }

    protected bool lightTriggerCheck(Collider2D collision)
    {
        return (lightInteractable && !active && collision.tag == "Light");
    }
    #endregion Trigger Condition Checks
}
