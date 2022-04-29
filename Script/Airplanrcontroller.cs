using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplanrcontroller : MonoBehaviour
{
    void Update()
    {
        //프레임 마다 등속 좌-->우 이동 시킨다.
        transform.Translate(0.025f, 0, 0);

        //화면 밖으로 나가면 오브젝트를 소멸 시킨다.
        if(transform.position.x > 5.0f)
        {
            Destroy(gameObject);
        }
    }
}
