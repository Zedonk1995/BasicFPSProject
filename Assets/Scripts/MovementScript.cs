using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementScript : MonoBehaviour
{
    BoxCollider myBoxCollider = null;
    Rigidbody myRigidbody = null;
    
    ILandMovementInput input = null;
    IIsMoving animatorController = null;

    bool isGrounded = true;
    RaycastHit groundCheckHit;

    Vector3 playerMoveInputDirection = Vector3.zero;
    Vector3 localCurrentVelocity = Vector3.zero;

    [Header("Movement Settings")]
    [SerializeField] float MaxSpeed = 10.0f;

    float DragCoefficient { get; set; } = 10.0f;
    float AirControlFactor { get; set; } = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        myBoxCollider = GetComponent<BoxCollider>();
        myRigidbody = GetComponent<Rigidbody>();

        input = GetComponent<ILandMovementInput>();
        animatorController = GetComponent<IIsMoving>();
    }

    void Update()
    {
        AnimateMovement();
    }

    void FixedUpdate()
    {
        isGrounded = Utils.IsGrounded(myBoxCollider, myRigidbody, out groundCheckHit);

        Vector3 currentVelocity = myRigidbody.velocity;
        localCurrentVelocity = transform.InverseTransformDirection(currentVelocity);
                   
        Vector3 moveInput = GetMoveInput();
        Vector3 propulsion = GetPropulsion(moveInput);

        myRigidbody.AddRelativeForce(propulsion * myRigidbody.mass, ForceMode.Force); // ForceMode.Force is the default value but I put in there for clarity
    }

    Vector3 GetMoveInput()
    {
        return new Vector3(input.MoveInput.x, 0.0f, input.MoveInput.y);
    }

    //this function works in local coordinates.
    Vector3 GetPropulsion(Vector3 moveInput)
    {
        if (IsAirborne())
        {
            return CalculateAirbornePropulsion(moveInput);
        }

        Vector3 directionOfPropulsion = GetDirectionOfGroundedPropulsion(moveInput);

        float slopeMultiplier = MovementSlopeMultiplier(directionOfPropulsion);

        // Unity cannot handle large numbers so drag is set to be proportional to velocity even though that's not actually how drag works
        Vector3 forceFromPlayer = DragCoefficient * MaxSpeed * directionOfPropulsion;
        Vector3 drag = DragCoefficient * localCurrentVelocity;

        return slopeMultiplier * forceFromPlayer - drag;
    }

    bool IsAirborne()
    {
        //If performance issue move get component to Start()
        // perf
        bool jumpRecentlyPressed = TryGetComponent(out Jump jumpScript) && jumpScript.JumpRecentlyPressed;

        return !isGrounded || jumpRecentlyPressed;
    }

    Vector3 CalculateAirbornePropulsion(Vector3 moveInput)
    {
        playerMoveInputDirection = moveInput.normalized;

        Vector3 airborneForceFromPlayer = AirControlFactor * MaxSpeed * playerMoveInputDirection;

        Vector3 horizontalPlayerVelocity = GetHorizontalPlayerVelocity();
        float horizontalPlayerSpeed = horizontalPlayerVelocity.magnitude;
        float playerForceInDirectionOfHorizontalVelocity = airborneForceFromPlayer.GetComponentInDirectionOf(horizontalPlayerVelocity);

        if (horizontalPlayerSpeed > MaxSpeed && playerForceInDirectionOfHorizontalVelocity >= 0)
        {
            Vector3 propulsion = airborneForceFromPlayer - playerForceInDirectionOfHorizontalVelocity * horizontalPlayerVelocity.normalized;
            return propulsion;
        }
        return airborneForceFromPlayer;
    }

    Vector3 GetHorizontalPlayerVelocity()
    {
        Vector3 playerVelocity = transform.InverseTransformDirection(myRigidbody.velocity);
        return Vector3.ProjectOnPlane(playerVelocity, Vector3.up);
    }

    Vector3 GetDirectionOfGroundedPropulsion(Vector3 moveInput)
    {
        playerMoveInputDirection = moveInput.normalized;

        Vector3 localGroundCheckHitNormal = transform.InverseTransformDirection(groundCheckHit.normal);

        Quaternion slopeAngleRotation = Quaternion.FromToRotation(Vector3.up, localGroundCheckHitNormal);

        return slopeAngleRotation * playerMoveInputDirection;
    }

    // Multiplier for doing down slopes (playerSlopeAngle is positive when going down slopes, negative otherwise)
    float MovementSlopeMultiplier(Vector3 directionOfPropulsion)
    {
        float playerSlopeAngle = directionOfPropulsion != Vector3.zero
            ? Vector3.Angle(Vector3.up, directionOfPropulsion) - 90
            : 0;

        float inverseSlopeFactor = 90f;

        /*
         *  To change the slope movement effect change inverseSlopeFactor.  If this is too low then zigzagging becomes the optimal strategy.
         *  The angle of slope where player has max vertical velocity is the solution this equation: 
         *  inverseSlopeFactor = theta + tan(theta)
         *  (theta is the angle the player is travelling up)
        */
        return 1 + playerSlopeAngle / inverseSlopeFactor;
    }
    
    void AnimateMovement()
    {
        if (animatorController == null)
        {
            return;
        }

        if (GetMoveInput() != Vector3.zero)
        {
            animatorController.IsMoving = true;
            return;
        }
        animatorController.IsMoving = false;
    }
}
