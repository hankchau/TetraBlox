using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        string tag_name = other.gameObject.tag;

        if (tag_name == "Goal")
        {
            // Win
            GameObject canvas = GameObject.Find("EndGameCanvas");

            foreach(Transform trans in canvas.transform)
            {
                if (trans.gameObject.tag == "GameWon")
                {
                    trans.gameObject.SetActive(true);

                    break;
                }
            }

            GameController.won = true;
        }
    }
}
