using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletIzq : MonoBehaviour
{

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.AddForce(new Vector2(-3.5f, 0));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "enemy1" || collision.transform.tag == "enemy2" || collision.transform.tag == "enemy3")
        {
            gameObject.GetComponent<HPManager>().TakeDamage(1);
        }
    }
}
