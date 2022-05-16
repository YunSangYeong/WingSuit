using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    float lengthSpeed = 0; //x축방향 스피드
    float hightSpeed = 0;  //y축방향 스피드
    Vector2 startPos;      //터치 시작포지션의 위치값
    Vector2 endPos;        //터치(스와이프) 종료포지션의 위치값
    Rigidbody2D rigid2D;
    Animator animator;
    float swipeLength;
    float swipeHight;
    public GameObject impect; //새나 비행기에 맞았을때 애니
    public GameObject crash;  //미사일에 맞았을 때 애니
    Vector2 playerObjectPositoin; //플레이어의 중심 좌표값

  
    //아래 두줄 돌던지기 관련
    public GameObject stoneFactory;
    //??이부분을 고쳐서 돌이 오브젝트 중심에서 떨어지지 않고, 머리 부분에서 떨어지게 조정(17번줄 변수와 연계) 17번은 뒤에 추가한것.
    public GameObject FirePosition; //이것 사용하지  않고, 쉽게하느것은 이 오브젝트의 축을 화살표로 마음에 드는 방향으로 이동 시키면 됨.



    //플레이어가 카메라 범위를 벗어나지 않도록 하는 것
    Vector2 playerMoveLimit; //변수 설정
    void Clamp() //Clamp라는 매서드
    {
        playerMoveLimit = transform.position;
        playerMoveLimit.x = Mathf.Clamp(playerMoveLimit.x, -2.2f, 2.2f);
        playerMoveLimit.y = Mathf.Clamp(playerMoveLimit.y, -4.4f, 4.4f);
        transform.position = new Vector2(playerMoveLimit.x, playerMoveLimit.y);
    }


    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }


    void Update()
    {
        Clamp(); //업데이트 함수 안에 위에서 정의한, 이동범위 제한인 Clamp 매서드 호출

        //스와이프의 길이를 구한다
        if (Input.GetMouseButtonDown(0))  //마우스에 Down하는 순간(즉, 터치하는 순간)
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

        

        //아래는 총알이 발사되는 스크립트

        //##이부분에 if분에 &&를 써서 한번에 하나의 스톤만 던져지게 할것 ?? 버튼누르게 해서 발사하기?? 코루틴 사용? 1초 마다 발사?

        if (Input.GetMouseButtonDown(0)) //사용자가 발사버튼을 누르면.
            {
                GameObject stone = Instantiate(stoneFactory);//stoneFactory라는 프리팹을 인스턴스한것을 stone변수에 넣는다.

                //스톤을 발사한다.(스톤을 스톤 발사위치로 가져다 둔다.)
                stone.transform.position = (FirePosition).transform.position;
            }    
    }


    //아래 OnCollisionEnter2D매서드를 Updata안에 넣으니 오류가 나더라.
    private void OnCollisionEnter2D(Collision2D col) //콜리전과 충돌이 일어나면.
    {
        if (col.gameObject.tag == "Enemy")  //충돌이 일어났는데 그 오브젝트 태그가Enemy라면.....(현재는 프립팹에 붙여짐)
        {
 //하이어라키창에있는 게임오브젝트중 이름이 "GmaeDirector"를 찾아서, GameObject타입의 director이라는변수에 할당해라
          GameObject director = GameObject.Find("GameDirector");


 //상기 director변수(즉GameDirctor이라는 오브젝트)에 있는 GameDirector라는 스크립트 컴포넌트의 DecresdeHP라는 메서드 
          director.GetComponent<GameDirector>().DecreaseHP();
  
            
//충돌시 폭발 애니매이션 프리팹을 불러서 재생하는 부분
        Instantiate(impect, this.transform.position, Quaternion.identity);

            //충돌시 소리나는 부분
            GetComponent<AudioSource>().Play();
        }


        if (col.gameObject.tag == "missle")  //충돌이 일어났는데 그 오브젝트 태그가 missle라면.....(현재는 프립팹에 붙여짐)
        {
            //하이어라키창에있는 게임오브젝트중 이름이 "GmaeDirector"를 찾아서, GameObject타입의 director이라는변수에 할당해라
            GameObject director = GameObject.Find("GameDirector");


            //상기 director변수(즉GameDirctor이라는 오브젝트)에 있는 GameDirector라는 스크립트 컴포넌트의 DecresdeHP라는 메서드 
            director.GetComponent<GameDirector>().DecreaseHP();


            //충돌시 폭발 애니매이션 프리팹을 불러서 재생하는 부분

            Instantiate(crash, this.transform.position, Quaternion.identity);

            //충돌시 소리나는 부분
            GetComponent<AudioSource>().Play();
        }
    }
}