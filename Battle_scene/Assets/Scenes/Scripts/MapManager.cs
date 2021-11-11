using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    // Start is called before the first frame update
    GameController manager;
    public Vector2 playerPos;
    Player player;

    void Awake() {
        //manager=GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameController>();    
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void Start()
    {

        manager=GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();    
    }

    // Update is called once per frame
    void Update()
    {
        playerPos=new Vector2(player.transform.position.x,player.transform.position.y);
    }
}
