using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleGameManager : MonoBehaviour
{
    Player_character player;
    Enemy_character enemy;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player_character>();
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy_character>();

    }

    // Update is called once per frame
    void Update()
    {
        if (player.isRun == true)
        {
            SceneManager.LoadScene("Map");
        }
    }
}
