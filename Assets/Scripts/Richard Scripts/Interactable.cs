using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public enum States
    {
        Active,
        Deactivate,
        Rest
    }

    [Header("Characters Interactable With")]
    public bool mothInteractable = false;
    public bool lightInteractable = false;

    protected States currentState = States.Rest;

    // Checks if specified objects are colliding
    private bool mothColliding = false;
    private bool lightColliding = false;

    private Animator anim;
    
    public virtual void Awake()
    {
        mothColliding = false;
        lightColliding = false;
        anim = GetComponent<Animator>();
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (mothTriggerCheck(collision))
            mothTriggerEffect();

        if (lightTriggerCheck(collision))
            lightTriggerEffect();
    }

    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Moth")
            mothLeaveEffect();

        if (collision.tag == "Light")
            lightLeaveEffect();
    }

    // Abstract methods for the trigger effects;
    public abstract void mothTriggerEffect();

    public abstract void lightTriggerEffect();

    public abstract void mothLeaveEffect();

    public abstract void lightLeaveEffect();

    
    #region Colliding Condition Check
    /*
    private bool mothCollidingCheck()
    {
        return (mothColliding && !active);
    }

    private bool lightCollidingCheck()
    {
        return (lightColliding && !active);
    }
    */
    #endregion Colliding Condition Check

    #region Trigger Condition Checks
    protected bool mothTriggerCheck(Collider2D collision)
    {
        return (mothInteractable && currentState != States.Active && collision.tag == "Moth");
    }

    protected bool lightTriggerCheck(Collider2D collision)
    {
        return (lightInteractable && currentState != States.Active && collision.tag == "Light");
    }
    #endregion Trigger Condition Checks
}
