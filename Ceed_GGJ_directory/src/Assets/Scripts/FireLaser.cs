using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLaser : MonoBehaviour
{
    private float timer = 5f;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<EnemyMovement>().chasing)
        {
            if(timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                gameObject.GetComponent<EnemyMovement>().canmove = false;
                if (gameObject.GetComponent<EnemyMovement>().isleft)
                {
                    animator.SetBool("ATTACKleft", true);
                }
                else if (!gameObject.GetComponent<EnemyMovement>().isleft)
                {
                    animator.SetBool("ATTACKright", true);
                }
                timer = 5f;
                gameObject.GetComponent<EnemyMovement>().canmove = true;
            }
        }
    }
}
