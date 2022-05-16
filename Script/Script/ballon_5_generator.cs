using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballon_5_generator : MonoBehaviour
{
    public GameObject ballon_4_Prefab;
    public float span = 8.0f;
    float delta = 0;


    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(ballon_4_Prefab);
            float px = Random.Range(-2.5f, 2.5f);
            go.transform.position = new Vector3(px, -8, 0);
        }
    }
}
