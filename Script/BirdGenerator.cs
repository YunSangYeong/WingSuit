using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdGenerator : MonoBehaviour
{

    public GameObject BirdPrefab;
    public float span = 1.0f;
    float delta = 0;

   

    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(BirdPrefab);
            float py = Random.Range(-4.67f, 4.63f);
            go.transform.position = new Vector3(4, py, 0);
        }
    }
}
