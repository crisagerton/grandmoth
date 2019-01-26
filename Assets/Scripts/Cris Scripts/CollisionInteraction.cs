using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionInteraction : MonoBehaviour
{
    //Basically replicates the Interactable class, but with colliders 
    [Header("Characters Interactable With")]
    public bool mothInteractable = false;
    public bool lightInteractable = false;

    protected bool active = false;

    // Checks if specified objects are colliding
    private bool mothColliding = false;
    private bool lightColliding = false;

    private Animator anim;

    public virtual void Awake()
    {
        active = false;
        mothColliding = false;
        lightColliding = false;
        anim = GetComponent<Animator>();
    }

    public virtual void Update()
    {
        // TEMP INPUT KEY
        if (mothCollidingCheck()) //&& Input.GetAxisRaw("MothInteract") != 0)
            mothTriggerEffect();

        if (lightCollidingCheck()) //&& Input.GetAxisRaw("LightInteract") != 0)
            lightTriggerEffect();

        if (active && anim)
        {
            anim.SetBool("activated", true);
        }
        //if (active && GetComponent<Rigidbody2D>()){
        //    GetComponent<Rigidbody2D>().active = false;
        //}
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (mothTriggerCheck(collision))
            mothColliding = true;

        if (lightTriggerCheck(collision))
            lightColliding = true;
    }

    // Overridable methods for the trigger effects;
    public virtual void mothTriggerEffect()
    {
        active = true;
    }

    public virtual void lightTriggerEffect()
    {
        active = true;
    }

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
    private bool mothTriggerCheck(Collision2D collision)
    {
        return (mothInteractable && !active && collision.transform.tag == "Moth");
    }

    private bool lightTriggerCheck(Collision2D collision)
    {
        return (lightInteractable && !active && collision.transform.tag == "Light");
    }
    #endregion Trigger Condition Checks
}
