using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stone_script : MonoBehaviour
{  void Update()
    {
        // //������ ������� �Ʒ��� ��������.
        transform.Translate(0, -0.03f, 0);

        //ȭ������� ������ �� ���� ������Ʈ�� �Ҹ� ��Ų��.
        if (transform.position.y < -8.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other) //�ݸ����� �浹�� �Ͼ��...
    {
        if (other.gameObject.tag == ("Enemy"))  //���� �浹�� �Ͼ ������Ʈ�� Enemy�±װ� �پ� �ִٸ�.
        {
            // �ٸ� ���� ������� �Ѵ�.
            Destroy(other.gameObject);

            //�ڽ��� ������� �Ѵ�.
            Destroy(this.gameObject);
        }
    }

}