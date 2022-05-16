using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballon_4_controller : MonoBehaviour
{
    void Update()
    {
        //프레임 마다 등속으로 수직이동하게 한다.
        //transform.Translate(0, 0.02f, 0);  리기드 바디로 수직이동 시킴

        //화면 밖으로 나가면 오브젝트를 소멸 시킨다.
        if (transform.position.y > 8.0f)
        {
            Destroy(gameObject);
        }
    }
}
