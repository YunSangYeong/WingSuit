using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject hpGauge;
    void Start()
    {
        this.hpGauge = GameObject.Find("hpGauge");
    }

    public void DecreaseHP()
    {
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.25f;

        //�Ʒ� �������� 0�� �Ǹ� ���� �ٲ�� ��
        if (this.hpGauge.GetComponent<Image>().fillAmount == 0)
        {
          SceneManager.LoadScene("Replay");
        }
    }  
}
