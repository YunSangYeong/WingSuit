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

        //아래 에너지가 0이 되면 씬이 바뀌는 것
        if (this.hpGauge.GetComponent<Image>().fillAmount == 0)
        {
          SceneManager.LoadScene("Replay");
        }
    }  
}
