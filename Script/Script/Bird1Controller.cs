using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird1Controller : MonoBehaviour
{
    void Update()
    {
        //������ ���� ������� �����̵��ϰ� �Ѵ�.
        transform.Translate(-0.02f, 0, 0);

        //ȭ�� ������ ������ ������Ʈ�� �Ҹ� ��Ų��.
        if(transform.position.x < -5.0f)
        {
            Destroy(gameObject);
        }
    }
}
