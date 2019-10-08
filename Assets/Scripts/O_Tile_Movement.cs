using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_Tile_Movement : MoveTile
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
        //Debug.Log(z);

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
