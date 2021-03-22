using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public GameObject player;
    private Object BrickRef;
    private Object WoodRef;
    private Object CementRef;
     private Object VigaRef;
     private Object AbonoRef;
     private Object LuzRef;
     private Object ParedRef;
     private Object ReciRef;
    public AudioSource Gameover;

    private float rand;
    // Start is called before the first frame update
    void Start()
    {
        BrickRef = Resources.Load("Brick_item");
        WoodRef = Resources.Load("Wood_item");
        CementRef = Resources.Load("Cemento_item");
        VigaRef = Resources.Load("Viga_item");
        AbonoRef = Resources.Load("Fertilizante_item");
        LuzRef = Resources.Load("CityEnergy_item");
        ParedRef = Resources.Load("wall_item");
        ReciRef = Resources.Load("FullHealth_item");
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<HPManager>().HP <= 0)
        {

            if (gameObject.tag != "Player")
            {
                rand = Random.Range(1f, 100f);
                if (gameObject.tag == "enemy1")
                {
                    if(rand > 25)
                    {
                        GameObject Brick = (GameObject)Instantiate(BrickRef);
                        Brick.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                        Brick.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10f));
                    }
                    if(rand > 35)
                    {
                        GameObject Wood = (GameObject)Instantiate(WoodRef);
                        Wood.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                        Wood.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 15f));
                    }
                }
                if(gameObject.tag == "enemy2")
                {
                    if(rand > 35)
                    {
                        GameObject Cement = (GameObject)Instantiate(CementRef);
                        Cement.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                        Cement.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 15f));
                    }
                    if(rand > 50)
                    {
                        GameObject Viga = (GameObject)Instantiate(VigaRef);
                        Viga.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                        Viga.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 20f));
                    }
                    if(player.GetComponent<HPManager>().HP < 50)
                    {
                        if(rand > 65)
                        {
                            GameObject Abono = (GameObject)Instantiate(AbonoRef);
                            Abono.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                            Abono.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 25f));
                        }
                    }
                }
                if(gameObject.tag == "enemy3")
                {
                    if(rand > 65)
                    {
                        GameObject Wall = (GameObject)Instantiate(ParedRef);
                        Wall.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                        Wall.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 30f));
                    }
                    if(rand < 25)
                    {
                        GameObject Luz = (GameObject)Instantiate(LuzRef);
                        Luz.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                        Luz.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 40f));
                        }
                    if(player.GetComponent<HPManager>().HP < 30)
                    {
                        if(rand > 90)
                        {
                            GameObject health = (GameObject)Instantiate(ReciRef);
                            health.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                            health.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 45f));
                        }
                    }
                    }
                Object.Destroy(gameObject);
            }
            else
            {
                Gameover.Play();
                GetComponent<BoxCollider2D>().enabled = false;
            }
           
        }
          
        }
    
    }
