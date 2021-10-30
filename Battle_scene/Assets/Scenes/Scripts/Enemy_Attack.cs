using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Attack : MonoBehaviour
{
    Rigidbody2D rigid;
    public int enemy_power=1;
    public bool enemy_attacking = false;
    public bool isDead = false;
    

    Charcter_Attack player;


    public float EnemyHP;
    public float EnemyMT;
    public float Speed=1.0f;

    public Image HPbar;

    void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Charcter_Attack>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }
    void Enemy_Move()
    {
        transform.Translate(Vector3.left * Speed * Time.deltaTime);
    }

    IEnumerator GetDamage()
    {

        //0.5�ʸ��� ������

        HPbar.fillAmount = EnemyHP / 1000;
        EnemyHP -= player.attackpower;
        yield return new WaitForSeconds(0.5f);

    }

    // Collider ������Ʈ�� is Trigger�� false�� ���·� �浹�� �������� ��

    void OnCollisionEnter2D(Collision2D other)

    {
        enemy_attacking = true;

    }



    // Collider ������Ʈ�� is Trigger�� false�� ���·� �浹���� ��

    void OnCollisionStay2D(Collision2D collision)

    {
        StartCoroutine("GetDamage");

    }



    // Collider ������Ʈ�� is Trigger�� false�� ���·� �浹�� ������ ��

    void OnCollisionExit2D(Collision2D collision)

    {
        enemy_attacking = false;

    }

    // Update is called once per frame
    void Update()
    {
        Enemy_Move();
        if (EnemyHP < 0)
        {
            isDead = true;
            enemy_attacking = false;

            Destroy(gameObject);
        }


/*        if ((player.isAttacking == true)&(player.isDead==false))
        {
            enemy_attacking = true;
            transform.position = new Vector3(1.4f, -0.4f, 0);

            StartCoroutine("GetDamage");

        }*/

/*        else 
        {
            enemy_attacking = false;
            transform.position = new Vector3(5, -0.4f, 0);
            
        }*/
    }

    
}
