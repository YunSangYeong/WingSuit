using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirpalneGenerator : MonoBehaviour
{
    public GameObject Airpalnefab;
    public float span_air = 1.0f;
    float delta_air = 0;


    void Update()
    {
        this.delta_air += Time.deltaTime;
        if (this.delta_air > this.span_air)
        {
            this.delta_air = 0;
            GameObject air = Instantiate(Airpalnefab);
            int py_air = Random.Range(-4, 4);
            air.transform.position = new Vector3(-4, py_air, 0);
        }
    }
}
