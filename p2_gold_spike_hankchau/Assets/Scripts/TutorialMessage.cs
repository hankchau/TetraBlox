using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMessage : MonoBehaviour
{
    bool showMsg = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (showMsg && Input.GetKeyDown(KeyCode.Mouse0))
        {
            showMsg = false;
            GameController.start = true;
            gameObject.SetActive(false);
        }
    }
}
