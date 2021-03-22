using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    int[] contador;
    // Start is called before the first frame update
    void Start()
    {
        contador = new int[6];
        for(int i = 0; i < 6; i++)
        {
            contador[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<HPManager>().HP > 0)
        {
            if (player.GetComponent<Player>().HitItem < 6)
            {
                contador[player.GetComponent<Player>().HitItem]++;
                player.GetComponent<Player>().HitItem = 9;
            } 
            else if (player.GetComponent<Player>().HitItem < 9 && player.GetComponent<Player>().HitItem > 6)
            {
                if (player.GetComponent<Player>().HitItem == 6)
                {
                    player.GetComponent<HPManager>().HP += 30;

                }
                else
                {
                    player.GetComponent<HPManager>().HP += 100;
                }
            }
        }
        else
        {
            //GAME OVER
            
        }
    }
}
