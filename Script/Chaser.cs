using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//여기에서 미사일 끝이 계속 유도되어 플레이어를 향하게 수정할 것
public class Chaser : MonoBehaviour
{
    GameObject target;
    public GameObject crash_animation;
    public float speed = 0.5f, rotSpeed = 10f;

    Quaternion rotTarget;
    Vector3 dir;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");

        //아래 미사일 회전 관련 연구해 볼것
        transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position);

    }

    void Update()
    {
        GuideMissle();
    }

    void GuideMissle()
    {
        dir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rotTarget = Quaternion.AngleAxis(angle, Vector3.zero); //이부분 zero로 바꾸니 유도탄 자세가 바르게 잡힘
        transform.rotation = Quaternion.Slerp(transform.rotation, rotTarget, Time.deltaTime * rotSpeed);
        rb.velocity = new Vector2(dir.x * speed, dir.y * speed);
    }
    void OnCollisionEnter2D(Collision2D other) //콜리전과 충돌이 일어나면...
    {
        if (other.gameObject.tag == "Player")  //Player태그가 붙은 오브젝트와 충돌이 일어 난다면....
        {
            //미사일 오브젝트를 파괴하라.
            Destroy(this.gameObject);

            //특유의 애니메이션 표현
            Instantiate(crash_animation, transform.position, Quaternion.identity);

            //이자리에 사운드 들어가는 무언가.
        }
    }
}
