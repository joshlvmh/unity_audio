using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    // Public Variables
    public Transform player;
    public float pickupRange = 1.0f;

    // Private Variables
    private bool isHeld = false;
    private new Rigidbody rigidbody;
    private Vector3 distanceToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        // Cache Rigid Body
        rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // 1. Store distance to the player from the axe
        distanceToPlayer = player.position - this.transform.position;

        // 2. See if the player is close enough and pressed E
        if (!isHeld && distanceToPlayer.magnitude <= pickupRange && Input.GetKeyDown(KeyCode.E))
        {
            // 3. Make axe a child of the player and reposition accordingly
            rigidbody.useGravity = false;
            rigidbody.isKinematic = true;
            this.transform.SetParent(player);
            this.transform.localPosition = new Vector3(0.5f, 0.0f, 0.5f);
            this.transform.localRotation = Quaternion.Euler(-45.0f, 0.0f, 0.0f);
            // 4. Signify the axe is now held
            isHeld = true;
        }
        // 5. See if the axe is already held and the player has pressed Q
        else if (isHeld && Input.GetKeyDown(KeyCode.Q))
        {
            // 6. Drop The Axe
            rigidbody.useGravity = true;
            rigidbody.isKinematic = false;
            this.transform.SetParent(null);
            isHeld = false;
        }
        
    }
}
