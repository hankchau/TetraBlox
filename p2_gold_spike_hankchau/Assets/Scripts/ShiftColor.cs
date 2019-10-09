using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftColor : MonoBehaviour
{
    Renderer rend;

    int counter = 0;
    bool change = true;
    int wait_time = 2;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (change)
        {
            change = false;
            StartCoroutine(Count());
        }
    }

    IEnumerator Count()
    {
        while (counter < wait_time)
        {
            yield return new WaitForSeconds(1);
            counter++;
        }

        if (counter == wait_time)
        {
            counter = 0;
            ChangeColor();
            change = true;
        }
    }

    void ChangeColor()
    {
        int num = Random.Range(0, 5);

        // blue
        if (num == 0)
        {
            rend.material.color = Color.blue;
        }
        // orange
        else if (num == 1)
        {
            rend.material.color = new Color(1, 0.5f, 0, 1);
        }
        // yellow
        else if (num == 2)
        {
            rend.material.color = Color.yellow;
        }
        // green
        else if (num == 3)
        {
            rend.material.color = Color.green;
        }
        // magenta
        else if (num == 4)
        {
            rend.material.color = Color.magenta;
        }
        // red
        else if (num == 5)
        {
            rend.material.color = Color.red;
        }
        // aqua?
    }
}
