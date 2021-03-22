using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipAttack : MonoBehaviour
{
    public float timer = 20f;
    GameObject defCheck;
    Animator animator;
    public float waiter = 1f;

    // Start is called before the first frame update
    void Start()
    {
        defCheck = GameObject.FindGameObjectWithTag("Player");
        animator = gameObject.GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (!defCheck.GetComponent<Player>().defending && !defCheck.GetComponent<Player>().jumping && timer <= 0)
            {
                timer = 0;

                if (defCheck.GetComponent<Player>().isleft){
                    animator.Play("whipLeft");
                }
                else
                {
                    animator.Play("WhipRight");
                }
                timer = 60f;
            }
            
        }
    }

}
