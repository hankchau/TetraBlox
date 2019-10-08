using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTile : MonoBehaviour
{
    public bool canMoveRight = true;
    public bool canMoveLeft = true;

    Rigidbody rb;
    bool is_active = true;
    bool is_moving = false;
    float offset;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (is_active)
        {
            rb = GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0, -3, 0);

            if (!is_moving)
            {
                GetInput();
            }
        }
    }

    void GetInput()
    {
        float horizontal_input = Input.GetAxisRaw("Joystick2Horizontal");
        //bool rotate = Input.GetKeyDown(KeyCode.Joystick2Button16);
        bool rotate = Input.GetKeyDown(KeyCode.UpArrow);
        float down = Input.GetAxisRaw("Joystick2Vertical");

        Vector3 destPos;

        if (horizontal_input > 0 && canMoveRight)
        {
            is_moving = true;
            destPos = transform.position + new Vector3(1, 0, 0);

            transform.position = destPos;
            CheckBorder();

            StartCoroutine(Count(0.1f));
        }

        else if (horizontal_input < 0 && canMoveLeft)
        {
            is_moving = true;
            destPos = transform.position + new Vector3(-1, 0, 0);

            transform.position = destPos;
            CheckBorder();

            StartCoroutine(Count(0.1f));
        }

        if (rotate)
        {
            if (CheckRotate())
            {
                Rotate();
            }

            CheckBorder();
        }

        else if (down < 0)
        {
            rb.velocity = new Vector3(0, -8, 0);
        }

        else if (down >= 0)
        {
            rb.velocity = new Vector3(0, -3, 0);
        }
    }

    // virtual func
    public virtual void Rotate()
    {
        transform.Rotate(0, 0, -90);

        float z = transform.eulerAngles.z;

        // check if move left by 1
        if (z - 90 < 0.001)
        {
            //Debug.Log("move left by 1");
            //transform.position += new Vector3(0, 0, 0);
        }

        // check if move right by 1
        else if (z - 0 < 0.001)
        {
            //Debug.Log("move right by 1");

            //transform.position += new Vector3(1, 0, 0);
        }

        CheckBorder();
    }

    public virtual bool CheckRotate()
    {
        // overwritten
        return false;
    }

    public virtual void CheckBorder()
    {
        // overwritten
    }

    void OnCollisionEnter(Collision collision)
    {
        string tag_name = collision.gameObject.tag;

        if (is_active && (tag_name == "Tetris" || tag_name == "Floor"))
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            rb.velocity = Vector3.zero;
            is_active = false;
            SpawnTetris.spawn = true;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        string tag_name = collision.gameObject.tag;
    }

    void OnCollisionExit(Collision collision)
    {
        string tag_name = collision.gameObject.tag;
    }

    IEnumerator Count(float num)
    {
        yield return new WaitForSeconds(num);
        is_moving = false;
    }
}
