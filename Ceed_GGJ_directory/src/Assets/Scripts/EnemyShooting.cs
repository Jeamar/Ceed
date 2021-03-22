using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    private float timer = 4f;
    private Animator animator;
    private Object bulletRef;
    private Object bulletIZRef;
    private bool shot;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponentInParent<Animator>();
        bulletRef = Resources.Load("PeattleProyectilDerecha");
        bulletIZRef = Resources.Load("PeattleProyIzq");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.GetComponentInParent<EnemyMovement>().chasing) {
            if (timer > 0)
            {
                animator.SetBool("ShootingLeft", false);
                animator.SetBool("ShootingRight", false);
                shot = false;
                timer -= Time.fixedDeltaTime;
            }
            else if(timer <= 0 && !shot)
            {
                if (gameObject.GetComponentInParent<EnemyMovement>().isleft)
                {
                    animator.SetBool("ShootingLeft", true);
                    GameObject bullet = (GameObject)Instantiate(bulletIZRef);
                    bullet.transform.position = gameObject.transform.position;
                    shot = true;
                }
                else
                {
                    animator.SetBool("ShootingRight", true);
                    GameObject bullet2 = (GameObject)Instantiate(bulletRef);
                    bullet2.transform.position = gameObject.transform.position;
                    shot = true;
                }
                timer = 4f;
            }

    }
    }
}
