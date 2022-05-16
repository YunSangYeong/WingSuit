using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolTimeScript : MonoBehaviour
{
    public Image image;
    public Button button;
    public float coolTime = 10.0f;
    public bool isClicked = false;

    //아래 애니재생 부분. 퍼블릭으로 하여 쿨타임 버튼 스크립트 컴포넌트에 아울렛을 만듬.
    public GameObject down;

    float leftTime = 10.0f;
    float speed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if(isClicked)
            if(leftTime > 0)
            {
                leftTime -= Time.deltaTime * speed;

                if(leftTime < 0)
                {
                    leftTime = 0;
                    if(button)
                      button.enabled = true;
                      isClicked = true;
                }

                float ratio = 1.0f - (leftTime / coolTime);
                if(image)
                   image.fillAmount = ratio;
            }
    }


    public void StartCoolTime()
    {
        leftTime = coolTime;
        isClicked = true;
        if (button)
           button.enabled = false; //버튼 기능을 해지함
    }
}
