using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTetris : MonoBehaviour
{
    public static bool spawn = true;
    public static string[] tetris_types = {"J_Tile", "L_Tile", "O_Tile",
                                     "S_Tile", "T_Tile", "Z_Tile", "I_Tile"};

    // Start is called before the first frame update
    void Start()
    {
        spawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            SpawnRandomTetris();
        }
    }

    void SpawnRandomTetris()
    {
        int num = Random.Range(0, 7);

        GameObject tetris = Resources.Load("Prefabs/" + tetris_types[num]) as GameObject;
        tetris.transform.position = transform.position;

        GameObject clone = Instantiate(tetris);
        SpawnTetris.spawn = false;
    }
}
