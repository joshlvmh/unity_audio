using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    // Public Variables
    public float sensitivity = 2.5f;

    // Private Variables
    private Vector2 mouseDirection, mouseDirectionChange;
    private Transform body;

    // Start is called before the first frame update
    void Start()
    {
        // Cache Body
        body = this.transform.parent.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // 1. Track Mouse Direction
        mouseDirectionChange = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseDirection += (sensitivity * mouseDirectionChange);

        // 2. Rotate body and Camera based on mouse position
        this.transform.localRotation = Quaternion.AngleAxis(-mouseDirection.y, Vector3.right);
        body.localRotation = Quaternion.AngleAxis(mouseDirection.x, Vector3.up);
    }


}
