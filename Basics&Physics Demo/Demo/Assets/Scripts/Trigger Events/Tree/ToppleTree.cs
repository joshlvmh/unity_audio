using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppleTree : MonoBehaviour
{
    // Public variable
    public float chopSpeed = 10.0f;
    public Score score;

    // Private Variables
    private new Rigidbody rigidbody;
    private Transform tree;
    private bool toppled = false;

    // Start is called before the first frame update
    void Start()
    {
        // Cache rigidbody
        rigidbody = this.GetComponentInParent<Rigidbody>();
        tree = this.transform.parent.transform;
    }

    void OnTriggerEnter(Collider other)
    {
        // 1. Check if Axe is held
        if (!toppled && other.gameObject.CompareTag("Player") && other.gameObject.GetComponentInChildren<Axe>() != null)
        {
            score.UpdateScore();
            // 2. Topple Tree
            StartCoroutine(ChopTree());
        }
        
    }

  
    private IEnumerator ChopTree()
    {
        // 3. Chop Tree and send flying
        toppled = true;
        rigidbody.isKinematic = false;
        rigidbody.velocity = new Vector3(Random.Range(-chopSpeed, chopSpeed), chopSpeed, Random.Range(-chopSpeed, chopSpeed));
        rigidbody.angularVelocity = new Vector3(Random.Range(-chopSpeed, chopSpeed), chopSpeed, Random.Range(-chopSpeed, chopSpeed));

        yield return new WaitForSeconds(10.0f); // waits 10 seconds

        // 4. Respawn Tree
        toppled = false;
        rigidbody.isKinematic = true;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        tree.localRotation = Quaternion.Euler(Vector3.zero);
        tree.localPosition = new Vector3(Random.Range(-8.0f, 8.0f), 1.0f, Random.Range(-8.0f, 8.0f));
    }
}
