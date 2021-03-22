using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    private bool canJump;
    private bool canmoveRight;
    private bool canmoveLeft;
    public bool isleft;
    private bool candef;
    public bool defending;
    public bool jumping;
    public int HitItem = 9;
    public AudioSource Salto;
    public AudioSource DañoCeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetBool("moving", false);
        animator.SetBool("movingLeft", false);

        if (Input.GetKey("d") && canmoveRight)
        {
            isleft = false;
            animator.SetBool("moving", true);
            animator.SetBool("idleLeft", false);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000f * Time.deltaTime, 0));
        }

        if (Input.GetKey("a")&& canmoveLeft)
        {
            isleft = true;
            animator.SetBool("movingLeft", true);
            animator.SetBool("idleLeft", true);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000f * Time.deltaTime, 0));
        }

        if(Input.GetKeyDown("space") && canJump)
        {
            jumping = true;
            candef = false;
            if (isleft)
            {
                animator.SetBool("Jump_left", true);

                canmoveRight = false;
            }
            else
            {

                canmoveLeft = false;
                animator.SetBool("jumping", true);
            }
            canJump = false;

            Salto.Play();
            
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1000f));
        }
        if (Input.GetKey(KeyCode.LeftShift) && candef) {
            if (isleft)
            {
                animator.SetBool("IzqDef", true);
            }
            else
            {
                animator.SetBool("DerDef", true);
            }
            canmoveLeft = canmoveRight = false;
            defending = true;

        }
        else
        {
            animator.SetBool("DerDef", false);
            animator.SetBool("IzqDef", false);
            defending = false;
            canmoveRight = canmoveLeft = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground")
        {
            animator.SetBool("jumping", false);
            animator.SetBool("Jump_left", false);
            canmoveRight = canmoveLeft = true;
            canJump = true;
            candef = true;
            jumping = false;
        }


        if (collision.transform.tag == "enemy1" || collision.transform.tag == "enemy2" || collision.transform.tag == "enemy3" || collision.transform.tag == "EnemyBullet" || collision.transform.tag == "enemyBeam" || collision.transform.tag == "Mine")
        {
            DañoCeed.Play();

            if (collision.transform.tag == "enemy1")
            {
                if (defending) {
                    gameObject.GetComponent<HPManager>().TakeDamage(5);
                }
                gameObject.GetComponent<HPManager>().TakeDamage(20);
            }
            else if (collision.transform.tag == "enemy2" || collision.transform.tag == "EnemyBullet")
            {
                if (defending)
                {
                    gameObject.GetComponent<HPManager>().TakeDamage(15);
                }
                gameObject.GetComponent<HPManager>().TakeDamage(40);
            }
            else if(collision.transform.tag == "Mine")
            {
                gameObject.GetComponent<HPManager>().TakeDamage(35);
            }
            else
            {
                if (defending)
                {
                    gameObject.GetComponent<HPManager>().TakeDamage(20);
                }
                gameObject.GetComponent<HPManager>().TakeDamage(60);
            }
            if (!defending)
            {
                if (isleft)
                {
                    animator.SetBool("tookdm_izq", true);
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(750f, 0));
                }
                else
                {
                    animator.SetBool("tookdmg_der", true);
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-750f, 0));
                }
            }
           
        }

        if (collision.transform.tag == "brick")
        {
            HitItem = 0;
        }

        else if (collision.transform.tag == "wood")
        {
            HitItem = 1;
        }
        else if (collision.transform.tag == "cement")

        {
            HitItem = 2;
        }
        else if (collision.transform.tag == "viga")
        {
            HitItem = 3;
        }
        else if (collision.transform.tag == "wall")
        {
            HitItem = 4;
        }
        else if (collision.transform.tag == "light")
        {
            HitItem = 5;
        }
        else if (collision.transform.tag == "health")
        {
            HitItem = 6;
        }
        else if (collision.transform.tag == "fullhp")
        {
            HitItem = 7;
       }

             
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.tag == "enemy1" || collision.transform.tag == "enemy2" || collision.transform.tag == "enemy3" || collision.transform.tag == "EnemyBullet" || collision.transform.tag == "enemyBeam" || collision.transform.tag == "Mine")
        {

            animator.SetBool("tookdmg_der", false);
            animator.SetBool("tookdm_izq", false);
        }
    }

    public bool getLeft()
    {
        return isleft;
    }
}

