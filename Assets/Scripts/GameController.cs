using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static bool start = false;
    public static bool won = false;
    public static bool lost = false;

    public static GameObject gameController;

    public void Awake()
    {
        Screen.SetResolution(1024, 768, false);

        if (gameController != null)
        {
            Destroy(gameObject);

            return;
        }

        // set permanent Game Controller
        gameController = gameObject;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Load Title Screen");
            LoadTitle();
        }

        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Start New Game");
            StartNewGame();
        }
    }

    public static void ResetVariables()
    {
        start = false;
        won = false;
    }

    public static void GameWonDisplay()
    {
        GameObject.FindGameObjectWithTag("GameWon").SetActive(true);
    }

    public static void GameOverDisplay()
    {
        GameObject.FindGameObjectWithTag("GameOver").SetActive(true);
    }

    public static void LoadTitle()
    {
        ResetVariables();
        SceneManager.LoadScene("Title");
    }

    public static void StartNewGame()
    {
        ResetVariables();
        SceneManager.LoadScene("SampleScene");
        start = true;
    }

    public static void StartTutorial()
    {
        ResetVariables();
        SceneManager.LoadScene("Tutorial");
    }
}
