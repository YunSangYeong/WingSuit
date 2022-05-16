using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    //ī�޶� ����
    public float ShakeAmount;   //ī�޶� ��鸮�� ���� �ѷ�, ���ڰ� �������� ī�޶� ��� ��鸲. �ۺ������ؼ� �ν���Ʈâ���� ����
    //public Canvas canvas;
    float ShakeTime;            //ī�޶� ��鸮�� �ð�
    Vector3 initialPosition;    //ī�޶� ��鸮�� ��ġ(����)

    public void VibrateForTime(float time)
    {
        ShakeTime = time;
        //canvas.renderMode = RenderMode.ScreenSpaceCamera;
        //canvas.renderMode = RenderMode.WorldSpace;
    }


    private void Start()
    {
        initialPosition = new Vector3(0f, 0f, -5f);  //ī�޶��� �ʱ� ��ġ��
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
