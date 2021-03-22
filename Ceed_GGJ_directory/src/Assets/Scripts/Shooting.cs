using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    private Animator animator;
    private Object bulletRef;
    private Object bulletIZRef;
    private GameObject defCheck;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponentInParent<Animator>();
        bulletRef = Resources.Load("Bullet");
        bulletIZRef = Resources.Load("BulletIzq");
        defCheck = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("ShootDer", false);
        animator.SetBool("ShootIzq", false);

        if (!defCheck.GetComponent<Player>().defending)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                if (gameObject.GetComponentInParent<Player>().isleft)
                {
                    animator.SetBool("ShootIzq", true);
                    GameObject bullet2 = (GameObject)Instantiate(bulletIZRef);
                    bullet2.transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);

                }
                else
                {
                    animator.SetBool("ShootDer", true);
                    GameObject bullet = (GameObject)Instantiate(bulletRef);
                    bullet.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                }
            }
        
        }
    }
}
