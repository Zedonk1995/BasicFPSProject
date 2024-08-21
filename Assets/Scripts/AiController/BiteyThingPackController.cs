using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiteyThingPackController : MonoBehaviour
{
    GameObject Player = null;

    int BitetyThingCounter = 1;

    // when a flanking monster gets within this distance, they will immediately head towards the player.
    readonly float startDirectChaseDistance = 2;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    private void Update()
    {
        BiteyThingController[] biteyThingControllers = (BiteyThingController[])Object.FindObjectsOfType(typeof(BiteyThingController));
        Vector3 playerPosition = Player.transform.position;

        BitetyThingCounter = 1;

        foreach (BiteyThingController biteyThingController in biteyThingControllers)
        {

            // twice as many monsters chase player as the number of monsters that perfrom any other singular role.
            switch (BitetyThingCounter % 6)
            {
                case 2:
                    HandleFlankTarget(biteyThingController, playerPosition + new Vector3(20, 0, 0), playerPosition);
                    break;
                case 3:
                    HandleFlankTarget(biteyThingController, playerPosition + new Vector3(-20, 0, 0), playerPosition);
                    break;
                case 4:
                    HandleFlankTarget(biteyThingController, playerPosition + new Vector3(0, 0, 20), playerPosition);
                    break;
                case 5:
                    HandleFlankTarget(biteyThingController, playerPosition + new Vector3(0, 0, -20), playerPosition);
                    break;
                default:
                    biteyThingController.SetTargetPosition();
                    break;
            }

            BitetyThingCounter++;
        }
    }

    /**
     * Handles when the flanking monsters should start to head directly towards their target/enemy.
     */
    void HandleFlankTarget(BiteyThingController biteyThingController, Vector3 targetPosition, Vector3 playerPosition)
    {
        float directChaseTimer = biteyThingController.directChaseTimer;

        if (directChaseTimer < 0)
        {
            if (biteyThingController.GetXZDistanceToTargetPosition() > startDirectChaseDistance)
            {
                biteyThingController.SetTargetPosition(targetPosition);
                return;
            }
            biteyThingController.SetTargetPosition();
            biteyThingController.directChaseTimer = 0f;
            return;
        }

        directChaseTimer += Time.fixedDeltaTime;

        if (directChaseTimer > biteyThingController.maxChaseTime)
        {
            biteyThingController.SetTargetPosition(targetPosition);
            biteyThingController.directChaseTimer = -1f;
            return;
        }

        biteyThingController.directChaseTimer = directChaseTimer;
    }
}
