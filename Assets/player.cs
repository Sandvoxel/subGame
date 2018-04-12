using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public float speed = 0f;
    public LayerMask groundLayers;

    Rigidbody rb;
    CapsuleCollider col;
    
	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
	}
	
	// Update is called once per frame
	void Update () {
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

		if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()){
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }

        if (IsGrounded() && Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * 0.9f, groundLayers);
    }
}
