using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird1Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
