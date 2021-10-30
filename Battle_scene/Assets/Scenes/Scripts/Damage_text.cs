using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage_text : MonoBehaviour
{
    Enemy_Attack enemy;
    Charcter_Attack player;

    public Text damage_player_text;
    public Text damage_enemy_text;



    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy_Attack>();
        player = GameObject.FindWithTag("Player").GetComponent<Charcter_Attack>();
        
    }

    IEnumerator destroy_text()
    {
        damage_player_text.gameObject.SetActive(true);
        damage_enemy_text.gameObject.SetActive(true);
        damage_player_text.text += "-" + enemy.enemy_power.ToString() + "\n";
        damage_enemy_text.text += "-" + player.attackpower.ToString() + "\n";
        yield return new WaitForSeconds(0.5f);

        damage_player_text.gameObject.SetActive(false);
        damage_enemy_text.gameObject.SetActive(false);

    }

    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(1.0f);
    }
    // Update is called once per frame
    void Update()
    {

        //transform.position = new Vector3((player_pos.x - enemy_pos.x), 0, 0);
        if (enemy.enemy_attacking == true)
        {
            if (enemy != null)
            {
                StartCoroutine("destroy_text");
                Debug.Log("РќХѕСп");
            }
            //damage_player_text.text += "-"+enemy.enemy_power.ToString()+"\n";
            
            //damage_player_text_2.gameObject.SetActive(true);
            //damage_player_text_3.gameObject.SetActive(true);
        }
    }
}
