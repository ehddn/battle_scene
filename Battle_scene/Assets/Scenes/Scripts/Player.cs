using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Player : MonoBehaviour
{
    public float h;
    public float v;
    public float Speed;

    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }
    void Move()
    {
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
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * Speed * Time.deltaTime);
        }
    }


    void OnCollisionEnter2D(Collision2D other)

    {
        Debug.Log("접촉");
        if (other.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("Battle");
        }
        

    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(h, v)*Speed*Time.deltaTime;
    }
}
