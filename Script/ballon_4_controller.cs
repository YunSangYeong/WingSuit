using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballon_4_controller : MonoBehaviour
{
    void Update()
    {
        //������ ���� ������� �����̵��ϰ� �Ѵ�.
        //transform.Translate(0, 0.02f, 0);  ����� �ٵ�� �����̵� ��Ŵ

        //ȭ�� ������ ������ ������Ʈ�� �Ҹ� ��Ų��.
        if (transform.position.y > 8.0f)
        {
            Destroy(gameObject);
        }
    }
}
