using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    public float kickForce = 10;
    public float rotationSpeed = 90;
    public GameObject player;
    public Transform body;
    private Rigidbody rb;
    private SphereCollider sc;
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        sc = GetComponent<SphereCollider>();
    } // End of Start

    private void OnTriggerStay(Collider other) {
        // Check if the player is in range and the player is shooting
        if(other.gameObject.name == "football-player" && other.transform.GetComponent<PlayerMovement>().isShooting) {
            rb.velocity += ((other.transform.forward * kickForce) + (new Vector3(0, 2, 0))); // Update velocity
        }
    } // End of OnTriggerStay

    // Code added to allow player to change position of ball
    private void OnMouseDown() {
        sc.enabled = false;
        rb.useGravity = false;
        rb.isKinematic = true;

        this.transform.position = body.position;
        this.transform.parent = player.transform;
    } // End of OnMouseDown

    private void OnMouseUp() {
        this.transform.parent = null;
        rb.useGravity = true;
        rb.isKinematic = false;
        sc.enabled = true;
    } // End of OnMouseUp
    // End of code added
}
