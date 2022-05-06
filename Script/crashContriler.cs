using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crashContriler : MonoBehaviour
{
    void Start()
    {//0.3초뒤에 이 스크립트에 연결된 오브젝트는 파괴.
        Destroy(this.gameObject, 0.3f);
    }
}

