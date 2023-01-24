using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    Rigidbody myRigidbody = null;
    ILandInput input = null;

    Vector3 moveInput = Vector3.zero;

    private Vector3 playerMoveInputDirection = Vector3.zero;
    private Vector3 localCurrentVelocity = Vector3.zero;

    public float maxSpeed { get; set; } = 10.0f;
    public float dragCoefficient { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        input = GetComponent<ILandInput>();

        dragCoefficient = 10.0f * myRigidbody.mass;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GetMoveInput()
    {
        return new Vector3(input.MoveInput.x, 0.0f, input.MoveInput.y);
    }

    private Vector3 getPlayerMove(Vector3 moveInput)
    {
        playerMoveInputDirection = new Vector3(moveInput.x, moveInput.y, moveInput.z).normalized;

        // Unity cannot handle large numbers so drag is set to be proportional to velocity even though that's not actually how drag works
        Vector3 propulsion = dragCoefficient * maxSpeed * playerMoveInputDirection;
        Vector3 drag = dragCoefficient * localCurrentVelocity;

        return propulsion - drag;
    }

    private void FixedUpdate()
    {
        Vector3 currentVelocity = myRigidbody.velocity;
        localCurrentVelocity = transform.InverseTransformDirection(currentVelocity);
        float speedSquared = Vector3.SqrMagnitude(localCurrentVelocity);

        moveInput = GetMoveInput();
        moveInput = getPlayerMove(moveInput);

        Debug.Log(localCurrentVelocity);

        myRigidbody.AddRelativeForce(moveInput, ForceMode.Force); // ForceMode.Force is the default value but I put in there for clarity

        if (speedSquared < 25.0f)
        {
            Vector3 localCurrentVelocityDirection = localCurrentVelocity.normalized;

            // force to make players come to a halt when moving at low speeds
            Vector3 stoppingForce = -5.0f * localCurrentVelocityDirection;
            myRigidbody.AddRelativeForce(stoppingForce * myRigidbody.mass, ForceMode.Force);
        }

    }


}
