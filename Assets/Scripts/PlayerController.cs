using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 30.0f;
    public float accelerationMetersASecondSquared = 5.0f;
    private Rigidbody2D body;
    private Vector2 playerInput;
    public enum FacingDirection {
        left, right
    }

    private FacingDirection direction;

    // Start is called before the first frame update
    void Start()
    {
	   body = GetComponent<Rigidbody2D>();  
           playerInput = Vector2.zero;
    }
   
    // Update is called once per frame
    void Update()
    {
        //The input from the player needs to be determined and then passed in the to the MovementUpdate which should
        //manage the actual movement of the character.
	if (Keyboard.current.dKey.wasPressedThisFrame)
		direction = FacingDirection.right;
	else if (Keyboard.current.aKey.isPressed)
		direction = FacingDirection.left;

	if (IsWalking())
		playerInput = (direction==FacingDirection.right) ? Vector2.right : Vector2.left;
	else
		playerInput = Vector2.zero;
    }

    void FixedUpdate()
    {
	    body.linearVelocity = body.linearVelocity+playerInput*accelerationMetersASecondSquared*Time.fixedDeltaTime;

	    if (body.linearVelocity.magnitude>maxSpeed)
		    body.linearVelocity = body.linearVelocity.normalized*maxSpeed;
    }

    public bool IsWalking()
    {
	    return Keyboard.current.aKey.isPressed || Keyboard.current.dKey.isPressed;
    }
    
    private void MovementUpdate(Vector2 playerInput)
    {
	    this.playerInput = playerInput;
    }

    public bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position,Vector2.down, 0.6f);
    }

    public FacingDirection GetFacingDirection()
    {
        return direction;
    }
}
