using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartNewGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        Debug.Log("Restarting");
        GameController.StartNewGame();
    }
}
