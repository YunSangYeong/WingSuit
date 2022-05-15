using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stone_script : MonoBehaviour
{
    Animator animator;
    public GameObject smoke;

    //아래 두줄은 돌이 적에에 맞으면 카메라 쉐이크 하는 변수
    CameraShake Camera;
    public float vibratefortime = 1.0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        Camera = GameObject.FindWithTag("MainCamera").GetComponent<CameraShake>();
    }
    void Update()
    {
        //스톤이 등속으로 아래로 떨어진다.
        //transform.Translate(0, -0.03f, 0);
        //리기드바디를 써서 이부분은 주석 처리함. 따라서 프레임마다 돌이 떨어지는 로직이 아니라, 중력으로 돌이 낙하하는 로직임



        //화면밖으로 나가면 이 스톤 오브젝트를 소멸 시킨다.
        if (transform.position.y < -8.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other) //다른 콜리전과 충돌이 일어나면...
    {
        
        if (other.gameObject.tag =="Enemy")   //만약 충돌이 일어난 오브젝트에 Enemy태그가 붙어 있다면.
        {

            //점수를 올린다. //Score라는 스크립트의 scre라는 변수에 1을 증감(++)시킨다. 즉, 콜라젼이 충돌이 일어날 때 마다. Score스크립트의 score변수를 증가시킨다.
            Score.score++;

         
            if (Score.score > Score.bestscore)
            {
                Score.bestscore = Score.score;
            }

            // 애니메이션을 작동시킨다. 
            Instantiate(smoke, this.transform.position, Quaternion.identity);

            // 다른 적을 사라지게 한다.
            Destroy(other.gameObject);

            // 스톤 자신을 사라지게 한다.
            Destroy(this.gameObject);

            //메인카메라에 있는 카메라쉐이크를 불러오는 위치, 즉 플레이어가 콜루전과 부딪쳐 죽는 순간 카메라 쉐이크 진동함
            Camera.VibrateForTime(vibratefortime);

            StartCoroutine(dealyforcamerashake());
            IEnumerator dealyforcamerashake()
            {
                yield return new WaitForSeconds(vibratefortime);
            }

        }


        if (other.gameObject.tag == "missle")   //만약 충돌이 일어난 오브젝트에 missle태그가 붙어 있다면.
        {

            //점수를 올린다. //Score라는 스크립트의 scre라는 변수에 1을 증감(++)시킨다. 즉, 콜라젼이 충돌이 일어날 때 마다. Score스크립트의 score변수를 증가시킨다.
            Score.score++;


            // 애니메이션을 작동시킨다. 
            Instantiate(smoke, this.transform.position, Quaternion.identity);

            // 다른 적을 사라지게 한다.
            Destroy(other.gameObject);

            // 스톤 자신을 사라지게 한다.
            Destroy(this.gameObject);

            //메인카메라에 있는 카메라쉐이크를 불러오는 위치, 즉 플레이어가 콜루전과 부딪쳐 죽는 순간 카메라 쉐이크 진동함
            Camera.VibrateForTime(vibratefortime);

            StartCoroutine(dealyforcamerashake());
            IEnumerator dealyforcamerashake()
            {
                yield return new WaitForSeconds(vibratefortime);
            }

        }

    }

}