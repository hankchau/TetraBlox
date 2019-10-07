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
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (is_active)
        {
            rb.velocity = new Vector3(0, -3, 0);

            if (!is_moving)
            {
                GetInput();
            }
        }
    }

    void GetInput()
    {
        float horizontal_input = Input.GetAxisRaw("Horizontal");
        bool up = Input.GetKeyDown(KeyCode.UpArrow);
        bool down = Input.GetKey(KeyCode.DownArrow);

        Vector3 destPos;

        if (horizontal_input > 0 && canMoveRight)
        {
            is_moving = true;
            destPos = transform.position + new Vector3(1, 0, 0);

            destPos = CheckBorder(destPos, "Right");

            transform.position = destPos;
            StartCoroutine(Count(0.1f));

        }

        else if (horizontal_input < 0 && canMoveLeft)
        {
            is_moving = true;
            destPos = transform.position + new Vector3(-1, 0, 0);

            destPos = CheckBorder(destPos, "Left");

            transform.position = destPos;
            StartCoroutine(Count(0.1f));
        }

        if (up)
        {
            destPos = transform.position;
            transform.Rotate(0, 0, -90);

            if (transform.position.x > 0)
            {
                destPos = CheckBorder(destPos, "Right");
            }

            else (transform.position.y > 0){
                destPos = CheckBorder(destPos, "Left");
            }

            transform.position = destPos;
        }

        else if (down)
        {
            rb.velocity = new Vector3(0, -8, 0);
        }

        else if (!down)
        {
            rb.velocity = new Vector3(0, -3, 0);
        }
    }

    Vector3 CheckBorder(Vector3 destPos, string dir)
    {
        float z = transform.eulerAngles.z;

        // find offset
        if (gameObject.name == "I_Tile")
        {
            if ((z % 360) < 0.0001 || (z % 180) < 0.0001)
            {
                offset = 0.5f;
            }

            else if ((z % 90) < 0.0001 || (z % 270) < 0.0001)
            {
                offset = 2f;
            }
        }

        // find destPos
        if (dir == "Right")
        {
            float x = destPos.x + offset;

            if (x > 8f)
            {
                destPos = new Vector3(8f - offset, destPos.y, 0);

                return destPos;
            }

            return destPos;
        }

        else
        {
            float x = destPos.x - offset;

            if (x < -8f)
            {
                destPos = new Vector3(-8f + offset, destPos.y, 0);

                return destPos;
            }

            return destPos;
        }
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

        else if (tag_name == "Border")
        {
            if (collision.gameObject.name.Contains("Left"))
            {
                canMoveLeft = false;
            }

            else if (collision.gameObject.name.Contains("Right"))
            {
                canMoveRight = false;
            }
        }
    }

    void OnCollisionStay(Collision collision)
    {
        string tag_name = collision.gameObject.tag;

        if (tag_name == "Border")
        {
            if (collision.gameObject.name.Contains("Left"))
            {
                canMoveLeft = false;
            }

            else if (collision.gameObject.name.Contains("Right"))
            {
                canMoveRight = false;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        string tag_name = collision.gameObject.tag;

        if (tag_name == "Border")
        {
            if (collision.gameObject.name.Contains("Left"))
            {
                canMoveLeft = true;
            }

            else if (collision.gameObject.name.Contains("Right"))
            {
                canMoveRight = true;
            }
        }
    }

    IEnumerator Count(float num)
    {
        yield return new WaitForSeconds(num);
        is_moving = false;
    }
}
