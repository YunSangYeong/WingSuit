using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impect_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {//0.5초뒤에 이 스크립트에 연결된 오브젝트는 파괴.
        Destroy(this.gameObject, 0.5f);
    }
}
