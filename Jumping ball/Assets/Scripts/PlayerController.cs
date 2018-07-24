using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float distToGround;

    public int Speed;
    public float PowerofJump;

    // Use this for initialization
    void Start ()
    {
        Speed = 15;
        PowerofJump = 400.0f;
	    rb = GetComponent<Rigidbody>();

        // get the distance to ground
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(0.0f, PowerofJump ,0.0f);
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * Speed);

    }
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
