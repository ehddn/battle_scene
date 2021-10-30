using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_damage_text : MonoBehaviour
{
    Enemy_Attack enemy;
    Charcter_Attack player;

    //public Text damage_player_text;
    public Text damage_enemy_text;


    // Start is called before the first frame update
    void Start()
    {
        //enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy_Attack>();
        player = GameObject.FindWithTag("Player").GetComponent<Charcter_Attack>();
    }

    IEnumerator destroy_text()
    {
        //damage_player_text.gameObject.SetActive(true);
        damage_enemy_text.gameObject.SetActive(true);
        //damage_player_text.text += "-" + enemy.enemy_power.ToString() + "\n";
        damage_enemy_text.text += "-" + player.attackpower.ToString() + "\n";
        yield return new WaitForSeconds(0.5f);

        //damage_player_text.gameObject.SetActive(false);
        damage_enemy_text.gameObject.SetActive(false);

    }
    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isAttacking == true)
        {
            
             StartCoroutine("destroy_text");
             Debug.Log("������");

        }
    }
}
