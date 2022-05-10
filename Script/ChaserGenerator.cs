using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserGenerator : MonoBehaviour
{
    public GameObject missle_Prefab;
    public float span = 3.0f;
    float delta = 0;


    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(missle_Prefab);
            float px = Random.Range(-4.67f, 4.63f);
            go.transform.position = new Vector3(px, -7, 0);
        }
    }
}