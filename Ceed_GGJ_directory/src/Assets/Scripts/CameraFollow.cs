using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform playerTransform;
    public float offset;
    private bool follow;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 punto = Camera.main.transform.position;
        Vector3 puntoir = playerTransform.position + new Vector3(0, 2.5f, -10);

        Camera.main.transform.position = Vector3.Lerp(punto, puntoir, offset);

       
    }

   
}
