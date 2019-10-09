using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Tile_Movement : MoveTile
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override bool CheckRotate()
    {
        return true;
    }

    public override void CheckBorder()
    {
        // check for rotation angle
        float offset;
        float z = transform.eulerAngles.z;
        //Debug.Log(z);

        // 0 degrees
        if (Mathf.Abs(z - 0) < 0.001f)
        {
            if (transform.position.x > 0)
            {
                offset = 1;

                if ((int)(transform.position.x + offset) >= 8)
                {
                    transform.position = new Vector3(8 - offset, transform.position.y, 0);
                }
            }

            else if (transform.position.x < 0)
            {
                offset = 2;

                if ((int)(transform.position.x - offset) <= -8)
                {
                    transform.position = new Vector3(-8 + offset, transform.position.y, 0);
                }
            }
        }

        // 180 degrees
        else if (Mathf.Abs(z - 180) < 0.001f)
        {

            if (transform.position.x > 0)
            {
                offset = 2;

                if ((int)(transform.position.x + offset) >= 8)
                {
                    transform.position = new Vector3(8 - offset, transform.position.y, 0);
                }
            }

            else if (transform.position.x < 0)
            {
                offset = 1;

                if ((int)(transform.position.x - offset) <= -8)
                {
                    transform.position = new Vector3(-8 + offset, transform.position.y, 0);
                }
            }
        }

        // -90 / 90 degrees
        else if (Mathf.Abs(z - 270) < 0.001f || Mathf.Abs(z - 90) < 0.001f)
        {
            offset = 1;

            if (transform.position.x + offset >= 8)
            {
                transform.position = new Vector3(8 - offset, transform.position.y, 0);
            }

            else if (transform.position.x - offset <= -8)
            {
                transform.position = new Vector3(-8 + offset, transform.position.y, 0);
            }
        }
    }
}
