using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplanrcontroller : MonoBehaviour
{
    void Update()
    {
        //������ ���� ��� ��-->�� �̵� ��Ų��.
        transform.Translate(0.025f, 0, 0);

        //ȭ�� ������ ������ ������Ʈ�� �Ҹ� ��Ų��.
        if(transform.position.x > 5.0f)
        {
            Destroy(gameObject);
        }
    }
}
