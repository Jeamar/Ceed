using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivarGameOver : MonoBehaviour
{
    public GameObject GameOver;
  
  public AudioSource Gameover;
  private bool isgameover = false;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -4.17f && !isgameover)
        {
          Gameover.Play();
            Invoke("ResetLvl", 1f);
            isgameover = true;

        }
    }
    void ResetLvl()
    {
        SceneManager.LoadScene("ceedproyect", LoadSceneMode.Single);
    }
}
