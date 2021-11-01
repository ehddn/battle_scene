using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_character : MonoBehaviour
{
    public int Hp;
    public int Mt;
    public int totalAir;
    public float Air;

    public int power;
    public int AtkDamage;
    public int defense;
    public int accuracy;
    public int avoid;
    public int critical;
    public int speed;

    private bool isDead;
    public bool isRun;
    public bool isAttack;
    public bool isCritical;

    public int exp;
    

    public Image HPbar;
    public Text damage_player_text;

    Rigidbody2D rigid;
    Enemy_character enemy;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy_character>();
    }


    void GetVictoryReward()
    {

    }

    void GetRunPenalty()
    {

    }

    void decreaseAir()
    {
        Air -= Time.deltaTime;
    }
    void Dead()
    {
        if ((Hp <= 0)||(Mt <= 0))
        {
            isDead = true;
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
    void checkAttack()
    {
        int check=1;
        //check = (accuracy - avoid + 30) / 100 * ((int)Air / totalAir);
        
        if (check <= 0)
        {
            isAttack = false;
        }
        else
        {
            isAttack = true;
        }
    }

    void checkCritical()
    {
        float check;
        check = (critical / 100) * (totalAir / Air);
        if (check >= 1)
        {
            isCritical = true;
        }
        else
        {
            isCritical = false;
        }

    }
    IEnumerator destroy_text()
    {

        damage_player_text.gameObject.SetActive(true);
        damage_player_text.text = "-" + (enemy.AtkDamage - defense).ToString() + "\n";
        yield return new WaitForSeconds(1.0f);
        damage_player_text.gameObject.SetActive(false);
        //damage_enemy_text.gameObject.SetActive(false);

    }
    void GetDamage()
    {
        if (enemy.isAttack == true)
        {
            if (enemy.isCritical == true)
            {
                if((enemy.AtkDamage - defense) <= 0)
                {
                    Hp = Hp;
                    HPbar.fillAmount = (float)Hp / 100;
                    /*rigid.AddForce(new Vector2(0,enemy.speed * 20));*/
                    StartCoroutine("destroy_text");
                }
                else
                {
                    Hp = Hp - (enemy.AtkDamage - defense);
                    HPbar.fillAmount = (float)Hp / 100;
                    StartCoroutine("destroy_text");
                }
               
            }
            else
            {
                if ((enemy.AtkDamage - defense) <= 0)
                {
                    Hp = Hp;
                    HPbar.fillAmount = (float)Hp / 100;
                    StartCoroutine("destroy_text");
                }
                else
                {
                    Hp = Hp - (enemy.AtkDamage - defense);
                    HPbar.fillAmount = (float)Hp / 100;
                    StartCoroutine("destroy_text");
                }
            }
        }
        Nulkback();

    }

    void playerAvoid()
    {

    }

    void Nulkback()
    {
        rigid.AddForce(new Vector2(-enemy.speed * 20, enemy.speed * 50));

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            checkAttack();
            checkCritical();
            if (isAttack == true)
            {
                if (isCritical == true)
                {
                    AtkDamage = (int)(power * 1.5);
                    print("플레이어 크리티컬 데미지!");
                }
                else
                {
                    AtkDamage = power;
                    print("플레이어 일반 데미지!");
                }
            }

            GetDamage();
        }
        else if (other.gameObject.tag == "RunTrigger")
        {
            isRun = true;
        }

    }
    //캐릭터 움직임
    void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        /*//오른쪽 키 때면 공격 멈춤. 근데 이러면 맞고만 있는건가? 잘 모르겠음
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            isAttacking = false;
            transform.position = new Vector3(-5, -0.4f, 0);
        }*/

        //왼쪽 키 누르면 도망감
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        /*if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }*/
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Dead();
        decreaseAir();
        

    }
}
