using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float timer = 2f;
    public float timer2 = 2f;
    public Animator animator;
    public float check;
    public bool chasing;
    private float relative;
    public bool isleft;
    public bool canmove;

    // Start is called before the first frame update
    void Start()
    {
        chasing = false;
        check = Random.Range(0f, 100f);
    }

    // Update is called once per frame
    void Update()
    {
        if (chasing)
        {
            chase();
        }
        else
        {
            idle();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "PlayerBullet")
        {
            gameObject.GetComponent<HPManager>().TakeDamage(25);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            chasing = true;
            relative = collision.transform.position.x;
        }
       
        if (collision.transform.tag == "PlayerWhip")
        {
            gameObject.GetComponent<HPManager>().TakeDamage(100);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            chasing = false;
            animator.SetBool("moving_right", false);
            animator.SetBool("moving_left", false);
            timer = Random.Range(2f, 6f);
            timer2 = Random.Range(2f, 4f);
        }
    }

    private void chase()
    {
        if(relative > gameObject.transform.position.x && canmove)
        {
            animator.SetBool("moving_right", true);
            isleft = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(600f * Time.deltaTime, 0));
        }
        else if(relative < gameObject.transform.position.x && canmove)
        {
            animator.SetBool("moving_left", true);
            isleft = true;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-600f * Time.deltaTime, 0));
        }
    }

    private void idle()
    {
        canmove = true;
        if (timer <= 0)
        {
            if (check <= 50)
            {
                animator.SetBool("moving_left", true);
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-600f * Time.deltaTime, 0));
                timer2 -= Time.deltaTime;
            }
            else
            {
                animator.SetBool("moving_right", true);
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(600f * Time.deltaTime, 0));
                timer2 -= Time.deltaTime;
            }
            if (timer2 <= 0)
            {
                check = Random.Range(0f, 100f);
                animator.SetBool("moving_right", false);
                animator.SetBool("moving_left", false);
                timer = Random.Range(2f, 6f);
                timer2 = Random.Range(2f, 4f);
            }
        }
        timer -= Time.deltaTime;
    }
}
