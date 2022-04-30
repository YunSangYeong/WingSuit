using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stone_script : MonoBehaviour
{
    void Update()
    {
        //스톤이 프레임마다 등속으로 아래로 이동한다.
        transform.Translate(0, -0.05f, 0);
        //화면밖으로 나가면 스톤 오브젝트를 소멸 시킨다.
        if (transform.position.y < -8.0f)
        {
            Destroy(gameObject);
        }
    }

}
