using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crashContriler : MonoBehaviour
{
    void Start()
    {//0.3�ʵڿ� �� ��ũ��Ʈ�� ����� ������Ʈ�� �ı�.
        Destroy(this.gameObject, 0.3f);
    }
}

