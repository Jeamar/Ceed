using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float direccion;
    Rigidbody2D rb2d;
    Object mineRef;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        mineRef = Resources.Load("Landmine");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.AddForce(new Vector2(direccion * 3.5f, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            gameObject.GetComponent<HPManager>().TakeDamage(1);
        }
        if(collision.transform.tag == "ground")
        {
            GameObject mina = (GameObject)Instantiate(mineRef);
            mina.transform.position = gameObject.transform.position;
            Object.Destroy(gameObject);
        }
    }
}
