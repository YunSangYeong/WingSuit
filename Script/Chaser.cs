using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    GameObject target;
   // GameObject missle_firepoint; //�̻����� �������� ���� ������ �ʾ�. ���� �׽�Ʈ �غ�
    public GameObject explosion;
    public float speed = 0.5f, rotSpeed = 10f;

    Quaternion rotTarget;
    Vector3 dir;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");
        // missle_firepoint = GameObject.Find("missle_firepoint");

        //�Ʒ� �̻��� ȸ�� ���� ������ ����
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
        rotTarget = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotTarget, Time.deltaTime * rotSpeed);
        rb.velocity = new Vector2(dir.x * speed, dir.y * speed);
    }
    void OnCollisionEnter2D(Collision2D other) //�ݸ����� �浹�� �Ͼ��...
    {
        if (other.gameObject.tag == ("Player"))  //Player�±װ� ���� ������Ʈ�� �浹�� �Ͼ� ���ٸ�....
        {
            //�̻��� ������Ʈ�� �ı��϶�.
            Destroy(this.gameObject);

            //Ư���� �ִϸ��̼� ǥ��

            //���ڸ��� ���� ���� ����.
            //Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }
}


