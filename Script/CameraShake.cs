using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    //카메라 흔들기
    public float ShakeAmount;   //카메라가 흔들리는 세기 총량, 숫자가 높을수록 카메라 쎄게 흔들림. 퍼블릭선언해서 인스펙트창에서 조정
    //public Canvas canvas;
    float ShakeTime;            //카메라가 흔들리는 시간
    Vector3 initialPosition;    //카메라가 흔들리는 위치(진원)

    public void VibrateForTime(float time)
    {
        ShakeTime = time;
        //canvas.renderMode = RenderMode.ScreenSpaceCamera;
        //canvas.renderMode = RenderMode.WorldSpace;
    }


    private void Start()
    {
        initialPosition = new Vector3(0f, 0f, -5f);  //카메라의 초기 위치값
    }

    private void Update()
    {
        if (ShakeTime > 0)
        {
            transform.position = Random.insideUnitSphere * ShakeAmount + initialPosition;
            ShakeTime -= Time.deltaTime;
        }

        else
        {
            ShakeTime = 0.0f;
            transform.position = initialPosition;
            //canvas.renderMode = RenderMode.ScreenSpaceCamera;
        }
    }
}
