using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    
    public Vector2 playerpos;
    public int playerHp;
    public int playerMt;
    public int playerAir;

    Player player;

    
    void SetPlayerPos()
    {
        player.transform.position = playerpos;
    }

    void GetPlayerPos()
    {
        playerpos = player.transform.position;
    }

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        //playerpos = new Vector2(player.transform.position.x, player.transform.position.y);*/
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        //SetPlayerPos();
        
        Debug.Log("게임 컨트롤러");
    }

    // Update is called once per frame
    void Update()
    {

        GetPlayerPos();

    }
    
}
