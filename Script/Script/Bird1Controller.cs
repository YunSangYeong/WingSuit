using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird1Controller : MonoBehaviour
{
    void Update()
    {
        //프레임 마다 등속으로 수평이동하게 한다.
        transform.Translate(-0.02f, 0, 0);

        //화면 밖으로 나가면 오브젝트를 소멸 시킨다.
        if(transform.position.x < -5.0f)
        {
            Destroy(gameObject);
        }
    }
}
