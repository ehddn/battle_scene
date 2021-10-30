using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Charcter_Attack : MonoBehaviour
{
    //�ϴ� public���� �� ����
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
        //������ �Է½� ����
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }
      
        /*//������ Ű ���� ���� ����. �ٵ� �̷��� �°� �ִ°ǰ�? �� �𸣰���
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            isAttacking = false;
            transform.position = new Vector3(-5, -0.4f, 0);
        }*/

        //���� Ű ������ ������
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isRun = true;
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }
    }
    IEnumerator GetDamage()
    {

        //0.5�ʸ��� ������

        HPbar.fillAmount = PlayerHP / 1000;
        PlayerHP -= enemy.enemy_power;
        yield return new WaitForSeconds(0.5f);

    }

    // Collider ������Ʈ�� is Trigger�� false�� ���·� �浹�� �������� ��

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



    // Collider ������Ʈ�� is Trigger�� false�� ���·� �浹���� ��

    void OnCollisionStay2D(Collision2D collision)

    {

        StartCoroutine("GetDamage");

    }



    // Collider ������Ʈ�� is Trigger�� false�� ���·� �浹�� ������ ��

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
