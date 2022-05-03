using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stone_script : MonoBehaviour
{  void Update()
    {
        // //스톤이 등속으로 아래로 떨어진다.
        transform.Translate(0, -0.03f, 0);

        //화면밖으로 나가면 이 스톤 오브젝트를 소멸 시킨다.
        if (transform.position.y < -8.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other) //콜리전과 충돌이 일어나면...
    {
        if (other.gameObject.tag == ("Enemy"))  //만약 충돌이 일어난 오브젝트에 Enemy태그가 붙어 있다면.
        {
            // 다른 적을 사라지게 한다.
            Destroy(other.gameObject);

            //자신을 사라지게 한다.
            Destroy(this.gameObject);
        }
    }

}