using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    public int Speed;
    public float PowerofJump;

    // Use this for initialization
    void Start ()
    {
        Speed = 15;
        PowerofJump = 300.0f;
	    rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(0.0f, PowerofJump ,0.0f);
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * Speed);

    }
}
