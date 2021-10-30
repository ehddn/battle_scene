using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Charcter_Attack : MonoBehaviour
{
    //일단 public으로 다 정의
    public float attackpower = 1f;

    Rigidbody2D rigid;


    public bool isAttacking=false;
    public bool isRun = false;
    public bool isDead = false;

    public float PlayerHP;
    public float PlayerMT;
    public float Speed;

    public Image HPbar;


    Enemy_Attack enemy;
    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy_Attack>();
        
        

    }


    void Attack()
    {
        //오른쪽 입력시 공격
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
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
            isRun = true;
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }
    }
    IEnumerator GetDamage()
    {

        //0.5초마다 데미지

        HPbar.fillAmount = PlayerHP / 1000;
        PlayerHP -= enemy.enemy_power;
        yield return new WaitForSeconds(0.5f);

    }

    // Collider 컴포넌트의 is Trigger가 false인 상태로 충돌을 시작했을 때

    void OnCollisionEnter2D(Collision2D other)

    {
        if (other.gameObject.tag == "Enemy")
        {
            isAttacking = true;
        }
        else if (other.gameObject.tag == "RunTrigger")
        {
            SceneManager.LoadScene("Map");
        }
        

    }



    // Collider 컴포넌트의 is Trigger가 false인 상태로 충돌중일 때

    void OnCollisionStay2D(Collision2D collision)

    {

        StartCoroutine("GetDamage");

    }



    // Collider 컴포넌트의 is Trigger가 false인 상태로 충돌이 끝났을 때

    private void OnCollisionExit(Collision collision)

    {
        isAttacking = false;

    }
    // Update is called once per frame
    void Update()
    {
        
        Attack();

        if (PlayerHP < 0)
        {
            isDead = true;
            gameObject.SetActive(false);
        }




    }

 

}
