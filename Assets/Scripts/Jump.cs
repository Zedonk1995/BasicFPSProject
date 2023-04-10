using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Jump : MonoBehaviour
{
    BoxCollider myBoxCollider = null;
    Rigidbody myRigidbody = null;
    ILandInput input = null;
    Gravity gravityScript = null;

    bool isGrounded = true;

    bool jumpIsPressed = false;

    float jumpHeight = 10f;
    float initialJumpSpeed;

    float jumpPressedTime = 0.0f;

    // number of seconds before jump can be pressed again
    float jumpCooldown = 0.5f;
    bool isJumpOffCooldown => Time.time - jumpPressedTime >= jumpCooldown;

    // records whether the player has pressed jump recently.
    // Needed to disable drag in the ground movement script  
    float jumpRecentlyPressedTimeLimit = 0.1f;
    public bool JumpRecentlyPressed => Time.time - jumpPressedTime <= jumpRecentlyPressedTimeLimit;

    // Start is called before the first frame update
    void Start()
    {
        myBoxCollider = GetComponent<BoxCollider>();
        myRigidbody = GetComponent<Rigidbody>();
        input = GetComponent<ILandInput>();

        gravityScript = GetComponent<Gravity>();
        var gravityStrength = gravityScript.GravityStrength;

        // initial jump speed is the square root of 2 times gravity times height.
        initialJumpSpeed = Mathf.Sqrt(2 * gravityStrength * jumpHeight);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        isGrounded = Utils.IsGrounded(myBoxCollider, myRigidbody, out _);

        jumpIsPressed = input.JumpIsPressed;

        if (jumpIsPressed == true && isJumpOffCooldown && isGrounded )
        {
            myRigidbody.AddForce(Vector3.up * initialJumpSpeed, ForceMode.VelocityChange);
            jumpPressedTime = Time.time;
        }
    }
}
