using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stone_script : MonoBehaviour
{
    void Update()
    {
        //������ �����Ӹ��� ������� �Ʒ��� �̵��Ѵ�.
        transform.Translate(0, -0.05f, 0);
        //ȭ������� ������ ���� ������Ʈ�� �Ҹ� ��Ų��.
        if (transform.position.y < -8.0f)
        {
            Destroy(gameObject);
        }
    }

}
