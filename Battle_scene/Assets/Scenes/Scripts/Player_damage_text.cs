using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_damage_text : MonoBehaviour
{
    Enemy_character enemy;
    Player_character player;

    public Text damage_player_text;
    //public Text damage_enemy_text;


    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy_character>();
        player = GameObject.FindWithTag("Player").GetComponent<Player_character>();
    }

    IEnumerator destroy_text()
    {
        
        damage_player_text.gameObject.SetActive(true); 
        //damage_enemy_text.gameObject.SetActive(true);
        damage_player_text.text += "-" + (enemy.AtkDamage-player.defense).ToString() + "\n";
        //damage_enemy_text.text += "-" + player.attackpower.ToString() + "\n";
        yield return new WaitForSeconds(1.5f);

        damage_player_text.gameObject.SetActive(false);
        //damage_enemy_text.gameObject.SetActive(false);

    }
    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.isAttack == true)
        {
            if (enemy != null)
            {
                StartCoroutine("destroy_text");
                Debug.Log("������");
            }
            //damage_player_text.text += "-"+enemy.enemy_power.ToString()+"\n";

            //damage_player_text_2.gameObject.SetActive(true);
            //damage_player_text_3.gameObject.SetActive(true);
        }
    }
}
