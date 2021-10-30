using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManeger : MonoBehaviour
{
    // Start is called before the first frame update
    Player_character player;

    //public int player_hp;
    //public int player_mt;
    public int player_air;

    public Text player_mt_text;
    public Text player_hp_text;
    public Image Airbar;


    //타이머
    public Text timerTxt;
    public float time = 59f;
    private float selectCountdown;

    void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player_character>();
        selectCountdown = time;


    }

    void Timer()
    {
        if (Mathf.Floor(selectCountdown) <= 0)
        {
            // Count 0일때 동작할 함수 삽입
        }
        else
        {
            selectCountdown -= Time.deltaTime;
            timerTxt.text = Mathf.Floor(selectCountdown).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        player_hp_text.text = player.Hp.ToString();
        player_mt_text.text = player.Mt.ToString();
        player_air = (int)player.Air;
        Timer();

        Airbar.fillAmount = player.Air / 100;
        //Air감소하는거 조정 필요, time.deltatime으로 초당 감소하게끔 보이도록, 지금 초당 감소하지만 실식산으로 계속 줄어드는것처럼 보임
    }
}
