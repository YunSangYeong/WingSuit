using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    float lengthSpeed = 0; //x����� ���ǵ�
    float hightSpeed = 0;  //y����� ���ǵ�
    Vector2 startPos;      //��ġ ������������ ��ġ��
    Vector2 endPos;        //��ġ(��������) ������������ ��ġ��
    Rigidbody2D rigid2D;
    Animator animator;
    float swipeLength;
    float swipeHight;
    public GameObject impect;

    //�Ʒ� ���� �������� ����
    public GameObject stoneFactory;
    public GameObject FirePosition;

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
           //���������� ���̸� ���Ѵ�
        if(Input.GetMouseButtonDown(0))  //���콺�� Down�ϴ� ����(��, ��ġ�ϴ� ����)
        {
            //���콺�� Ŭ���� ��ǥ
            this.startPos = Input.mousePosition;
        }

        else if (Input.GetMouseButtonUp(0))  //���콺���� Up�ϴ� ����(��, ��ġ���� �� ���� ����)
        {
            //���콺 ��ư���� �հ����� ������ �� ��ǥ
            endPos = Input.mousePosition;

            //x�� ���̸� ���Ѵ�(���콺Ŭ���� ������ x��ǥ - ���콺���� �ն��� ������ x��ǥ)
            swipeLength = (this.startPos.x - endPos.x) / 6 ; //������ 3�� �ʹ� ���ϰ� �����̱� �ʰ� �ϱ�����.

            //y�� ���̸� ���Ѵ�(���콺Ŭ���� ������ y��ǥ - ���콺���� �ն��� ������ y��ǥ)
            swipeHight = (this.startPos.y - endPos.y) /  6; //������ 3�� �ʹ� ���ϰ� �����̱� �ʰ� �ϱ�����.

            //�������� ���̸� ó�� �ӵ��� �����Ѵ�.
            this.lengthSpeed = swipeLength / 500.0f;  //��ǥ���� 500�� �����, õõ�� 0�̵ǰ� �Ѵ�.
            this.hightSpeed = swipeHight  /  500.0f;  //��ǥ���� 500�� �����, õõ�� 0�̵ǰ� �Ѵ�.
        }

        transform.Translate(this.lengthSpeed, 0, 0); //�̵� x���� lgngthSpeeed
        transform.Translate(0,this.hightSpeed, 0);  //�̵�  y���� hightSpeed

        //�÷��̾ ����Ҷ�, �� y���� ������ ���� 0���� Ŭ�� UpMove�ִϸ��̼� ����ϵ��� ��.
        if (swipeHight < 0)
        {
            this.animator.SetTrigger("Up Trigger");

        }
        this.lengthSpeed *= 0.98f;  //���� 0.98�� ����� õõ�� 0�� �ǰ� �Ѵ�
        this.hightSpeed *= 0.98f;  //���� 0.98�� ����� õõ�� 0�� �ǰ� �Ѵ� 

        //�Ʒ��� �Ѿ��� �߻�Ǵ� ��ũ��Ʈ

        //##�̺κп� if�п� &&�� �Ἥ �ѹ��� �ϳ��� ���游 �������� �Ұ� ?? ��ư������ �ؼ� �߻��ϱ�??
       
            if (Input.GetMouseButtonUp(0)) //����ڰ� �߻��ư�� ������.
            {
                GameObject stone = Instantiate(stoneFactory);//stoneFactory��� �������� �ν��Ͻ��Ѱ��� stone������ �ִ´�.

                //������ �߻��Ѵ�.(������ ���� �߻���ġ�� ������ �д�.)
                stone.transform.position = FirePosition.transform.position;
            }
       
    }


    //�Ʒ� OnCollisionEnter2D�ż��带 Updata�ȿ� ������ ������ ������.
    private void OnCollisionEnter2D(Collision2D col) //�ݸ����� �浹�� �Ͼ��.
    {
        if (col.gameObject.tag == "Enemy")  //Enemy�±װ� �����Ϳ� �۵��ض�(�����տ� �ٿ���)
        {
 //���̾��Űâ���ִ� ���ӿ�����Ʈ�� �̸��� "GmaeDirector"�� ã�Ƽ�, GameObjectŸ���� director�̶�º����� �Ҵ��ض�
          GameObject director = GameObject.Find("GameDirector");

 //��� director����(��GameDirctor�̶�� ������Ʈ)�� �ִ� GameDirector��� ��ũ��Ʈ ������Ʈ�� DecresdeHP��� �޼��� 
          director.GetComponent<GameDirector>().DecreaseHP();
        
        //�浹�� ���� �ִϸ��̼� �������� �ҷ��� ����ϴ� �κ�
        Instantiate(impect, this.transform.position, Quaternion.identity);
        }
    }
}