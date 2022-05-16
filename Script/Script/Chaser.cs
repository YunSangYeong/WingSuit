using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//���⿡�� �̻��� ���� ��� �����Ǿ� �÷��̾ ���ϰ� ������ ��
public class Chaser : MonoBehaviour
{
    GameObject target;
    //public GameObject crash_animation;
    public float speed = 0.5f, rotSpeed = 0.5f;

    Quaternion rotTarget;
    Vector3 dir;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");

        //�Ʒ� �̻��� ȸ�� ���� ������ ����
        //transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position);

    }

    void Update()
    {
        GuideMissle();
    }

    void GuideMissle()
    {
        dir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rotTarget = Quaternion.AngleAxis(angle-90, Vector3.forward); //�̻����� ������ �����̴°��� angle-90 rhk Vector3.forward�� �ذ���.
        transform.rotation = Quaternion.Slerp(transform.rotation, rotTarget, Time.deltaTime * rotSpeed);
        rb.velocity = new Vector2(dir.x * speed, dir.y * speed);
    }
    void OnCollisionEnter2D(Collision2D other) //�ݸ����� �浹�� �Ͼ��...
    {
        if (other.gameObject.tag == "Player")  //Player�±װ� ���� ������Ʈ�� �浹�� �Ͼ� ���ٸ�....
        {
            //�̻��� ������Ʈ�� �ı��϶�.
            Destroy(this.gameObject);
        }
    }
}
