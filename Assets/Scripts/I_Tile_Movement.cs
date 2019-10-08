using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_Tile_Movement : MoveTile
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Rotate()
    {
        transform.Rotate(0, 0, -90);
        CheckBorder();
    }

    public override bool CheckRotate()
    {
        float z = transform.eulerAngles.z;

        if (Mathf.Abs(z - 270) < 0.001f || Mathf.Abs(z - 90) < 0.001f)
        {
            // do raycast
            bool leftHit = Physics.Raycast(transform.position, Vector3.left, 2);
            bool rightHit = Physics.Raycast(transform.position, Vector3.right, 2);

            if (!leftHit && !rightHit)
            {
                return true;
            }
        }

        return true;
    }

    public override void CheckBorder()
    {
        // check for rotation angle
        float offset;
        float z = transform.eulerAngles.z;
        Debug.Log(z);

        // 0 degrees / 180 degrees
        if (Mathf.Abs(z - 0) < 0.001f || Mathf.Abs(z - 180) < 0.001f)
        {
            offset = 2;

            if ((int)(transform.position.x + offset) >= 8)
            {
                transform.position = new Vector3(8 - offset, transform.position.y, 0);
            }

            else if ((int)(transform.position.x - offset) <= -8)
            {
                transform.position = new Vector3(-8 + offset, transform.position.y, 0);
            }
        }
        // -90 degrees
        else if (Mathf.Abs(z - 270) < 0.001f)
        {
            if (transform.position.x > 0)
            {
                offset = 1;
                if ((int)(transform.position.x + offset) >= 8)
                {
                    transform.position = new Vector3(8 - offset, transform.position.y, 0);
                }
            }

            else if (transform.position.x <= -8)
            {
                transform.position = new Vector3(-8, transform.position.y, 0);
            }
        }

        // 90 degrees
        else if (Mathf.Abs(z - 90) < 0.001f)
        {
            if (transform.position.x < 0)
            {
                offset = 1;
                if ((int)(transform.position.x - offset) <= -8)
                {
                    transform.position = new Vector3(-8 + offset, transform.position.y, 0);
                }
            }

            else if (transform.position.x >= 8)
            {
                transform.position = new Vector3(8, transform.position.y, 0);
            }
        }
    }
}
