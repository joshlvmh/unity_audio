using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Public Variables
    public float speed = 0.01f;

    // Private Variables
    private float sideToSideDirection;
    private float forwardAndBackwardDirection;
    private Vector3 moveDirection, cameraForward, cameraRight;
    private new Camera camera;
    private new Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        // Cache Camera
        camera = this.GetComponentInChildren<Camera>();
        rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // 1. Get key presses relating to horizontal/forward movement 
        sideToSideDirection = Input.GetAxis("Horizontal");
        forwardAndBackwardDirection = Input.GetAxis("Vertical");

        // 2. Get Vectors related to where the camera is looking
        cameraForward = camera.transform.forward;
        cameraRight = camera.transform.right;

        // 3. Move in direction relative to where the camera is looking
        moveDirection = (sideToSideDirection * cameraRight) + (forwardAndBackwardDirection * cameraForward);
        moveDirection.y = 0.0f;

        // 4. Update Player position
        this.transform.position += (speed * moveDirection);

        // 5. Ignore Rigidbody's velocity to stop movement after a collision
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;



    }

}
