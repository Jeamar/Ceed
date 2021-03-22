using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float nextEn = 1;
    public float minran = 1;
    public float maxran = 10f;
    public float spawndistance = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nextEn -= Time.deltaTime;
        if (nextEn <= 0)
        {
            nextEn = Random.Range(minran, maxran);

            Vector3 offset = Random.onUnitSphere;
            offset.z = 0;
            offset.y = 0;
            offset = offset.normalized * spawndistance;
            Instantiate(EnemyPrefab, transform.position + offset, Quaternion.identity);
        }
    }
}
