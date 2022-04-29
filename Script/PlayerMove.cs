using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    float lengthSpeed = 0; //x축방향 스피드
    float hightSpeed = 0;  //y축방향 스피드
    Vector2 startPos;      //터치 시작포지션의 위치값
    Vector2 endPos;        //터치(스위이프) 종료포지션의 위치값
    Rigidbody2D rigid2D;
    Animator animator;
    float swipeLength;
    float swipeHight;

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
           //스와이프의 길이를 구한다
        if(Input.GetMouseButtonDown(0))  //마우스에 Down하는 순간(즉, 터치하는 순간)
        {
            //마우스를 클릭한 좌표
            this.startPos = Input.mousePosition;
        }

        else if (Input.GetMouseButtonUp(0))  //마우스에서 Up하는 순간(즉, 터치에서 손 데는 순간)
        {
            //마우스 버튼에서 손가락을 떼었을 때 좌표
            endPos = Input.mousePosition;

            //x쪽 길이를 구한다(마우스클릭한 순간의 x좌표 - 마우스에서 손떼는 순간의 x좌표)
            swipeLength = (this.startPos.x - endPos.x) / 6 ; //나누기 3은 너무 급하게 움직이기 않게 하기위해.

            //y쪽 길이를 구한다(마우스클릭한 순간의 y좌표 - 마우스에서 손떼는 순간의 y좌표)
            swipeHight = (this.startPos.y - endPos.y) /  6; //나누기 3은 너무 급하게 움직이기 않게 하기위해.

            //스와이프 길이를 처음 속도로 변경한다.
            this.lengthSpeed = swipeLength / 500.0f;  //좌표값에 500을 나누어서, 천천히 0이되게 한다.
            this.hightSpeed = swipeHight  /  500.0f;  //좌표값에 500을 나누어서, 천천히 0이되게 한다.
        }

        transform.Translate(this.lengthSpeed, 0, 0); //이동 x축은 lgngthSpeeed
        transform.Translate(0,this.hightSpeed, 0);  //이동  y축은 hightSpeed

        //플레이어가 상승할때, 즉 y축이 포지션 값이 0보다 클때 UpMove애니메이션 재생하도록 함.
        if (swipeHight < 0)
        {
            this.animator.SetTrigger("Up Trigger");

        }
        this.lengthSpeed *= 0.98f;  //감속 0.98을 나누어서 천천히 0이 되게 한다
        this.hightSpeed *= 0.98f;  //감속 0.98을 나누어서 천천히 0이 되게 한다
    }
    //아래 OnCollisionEnter2D매서드를 Updata안에 넣으니 오류가 나더라.
    private void OnCollisionEnter2D(Collision2D col) //콜리전과 충돌이 일어나면.
    {
        if (col.gameObject.tag == "Enemy")  //Enemy태그가 붙은것에 작동해라(프립팹에 붙여짐)
        {
 //하이어라키창에있는 게임오브젝트중 이름이 "GmaeDirector"를 찾아서, GameObject타입의 director이라는변수에 할당해라
          GameObject director = GameObject.Find("GameDirector");
 //상기 director변수(즉GameDirctor이라는 오브젝트)에 있는 GameDirector라는 스크립트 컴포넌트의 DecresdeHP라는 메서드 
          director.GetComponent<GameDirector>().DecreaseHP();
        }
    }
}