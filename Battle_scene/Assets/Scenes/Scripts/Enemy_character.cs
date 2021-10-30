using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_character : MonoBehaviour
{

    public int Hp;


    public int power;
    public int AtkDamage;
    public int defense;
    public int accuracy;
    public int avoid;
    public int critical;
    public int speed;

    private bool isDead;
    private bool isRun;
    public bool isAttack;
    public bool isCritical;


    Rigidbody2D rigid;
    Player_character player;
    public Image HPbar;
    public Text damage_enemy_text;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").GetComponent<Player_character>();
    }


    void Enemy_Move()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void Dead()
    {
        if (Hp <= 0)
        {
            isDead = true;
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
    IEnumerator destroy_text()
    {

        damage_enemy_text.gameObject.SetActive(true);
        damage_enemy_text.text = "-" + (player.AtkDamage - defense).ToString() + "\n";
        yield return new WaitForSeconds(1.0f);
        damage_enemy_text.gameObject.SetActive(false);
        //damage_enemy_text.gameObject.SetActive(false);

    }

    //넉백 수정필요
    void Nulkback()
    {
        rigid.AddForce(new Vector2(player.speed * 50, player.speed * 50));

    }
    void GetDamage()
    {
        if (player.isAttack == true)
        {
            //한번 부딪히고 다음에 멈추는 버그 있음 
            if (player.isCritical == true)
            {
                if ((player.AtkDamage - defense) <= 0)
                {
                    Hp = Hp;
                    HPbar.fillAmount = (float)Hp / 100;
                    
                    StartCoroutine("destroy_text");
                }
                else
                {
                    Hp = Hp - (player.AtkDamage - defense);
                    HPbar.fillAmount = (float)Hp / 100;
                    StartCoroutine("destroy_text");
                }

            }
            else
            {
                if ((player.AtkDamage - defense) <= 0)
                {
                    Hp = Hp;
                    HPbar.fillAmount = (float)Hp / 100;
                    StartCoroutine("destroy_text");
                }
                else
                {
                    Hp = Hp - (player.AtkDamage - defense);
                    HPbar.fillAmount = (float)Hp / 100;
                    StartCoroutine("destroy_text");
                }
            }
                        
            //Hp = Hp - (player.AtkDamage - defense);
            /*Hp -= 100;
            HPbar.fillAmount = (float)Hp / 100;*/

        }
        Nulkback();

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isAttack = true;
            //rigid.AddForce(Vector3.right * player.speed * 20);
            GetDamage();

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Enemy_Move();
        Dead();
    }
}
