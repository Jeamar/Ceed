using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    public float HP;
    private GameObject HPbar;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (HP >= 100) {

            HP = 100;
        }
        if (HP <= 0)
        {
            HP = 0;
        }

        if(gameObject.tag == "Player")
        {
            
        }

    }

    public void TakeDamage(float dmg)
    {
        HP -= dmg;
    }
}
