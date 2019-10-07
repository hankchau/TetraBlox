using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jump_height = 5;
    public bool canMoveLeft = true;
    public bool canMoveRight = true;


    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        float input_horizontal = Input.GetAxisRaw("Horizontal");

        if (input_horizontal > 0)
        {
            rb.velocity = new Vector3(3, rb.velocity.y, 0);
        }

        else if (input_horizontal < 0)
        {
            rb.velocity = new Vector3(-3, rb.velocity.y, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GroundCheck())
            {
                Debug.Log("Jump!");
                Jump();
            }
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(0, jump_height, 0);
    }

    bool GroundCheck()
    {
        //RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, 0.6f))
        {
            return true;
        }

        return false;
    }
}
