using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBorder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionStay(Collision collision)
    {
        //CheckBorder();
    }

    void CheckBorder()
    {
        if (name.Contains("Border (Left)"))
        {
            RaycastHit[] right_hits = Physics.RaycastAll(transform.position, Vector3.right, 0.6f);

            foreach (RaycastHit hit in right_hits)
            {
                if (hit.collider.gameObject.tag == "Tetris")
                {
                    hit.collider.gameObject.GetComponent<MoveTile>().canMoveLeft = false;
                }

                else if (hit.collider.gameObject.tag == "Player")
                {
                    hit.collider.gameObject.GetComponent<PlayerController>().canMoveRight = false;
                }
            }
        }

        else if (name.Contains("Border (Right)"))
        {
            Debug.Log("Touched Border (Right)");
            RaycastHit[] left_hits = Physics.RaycastAll(transform.position, Vector3.left, 1.5f);

            Debug.Log(left_hits.Length);

            foreach (RaycastHit hit in left_hits)
            {
                if (hit.collider.gameObject.tag == "Tetris")
                {
                    Debug.Log("It was a Tetris!");
                    hit.collider.gameObject.GetComponent<MoveTile>().canMoveRight = false;
                }

                else if (hit.collider.gameObject.tag == "Player")
                {
                    Debug.Log("It was a Player!");
                    hit.collider.gameObject.GetComponent<PlayerController>().canMoveRight = false;
                }
            }
        }
    }

    void GoalBounceChek()
    {

    }
}
