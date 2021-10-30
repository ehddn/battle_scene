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


    //Ÿ�̸�
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
            // Count 0�϶� ������ �Լ� ����
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
        //Air�����ϴ°� ���� �ʿ�, time.deltatime���� �ʴ� �����ϰԲ� ���̵���, ���� �ʴ� ���������� �ǽĻ����� ��� �پ��°�ó�� ����
    }
}
