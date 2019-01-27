using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class CountDown : MonoBehaviour
{
    public int timeLeft = 120;
    public int timeOneMin = 0;
    public Text countdown;
    void Start()
        
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1; 
    }
    void Update()
    {
        if (timeLeft == 120)

        {
            countdown.text = ("2:00");
        }

       if(timeLeft >= 60 && timeLeft != 120)
        {
           timeOneMin = timeLeft - 60;
            countdown.text = ("1:") + timeOneMin;      
        }

        if (timeLeft <= 69)
        {
            timeOneMin = timeLeft - 60;
            countdown.text = ("1:0" + timeOneMin);
        }

        if (timeLeft < 60)
        {
            countdown.text = ("0:" + timeLeft);
        }
        if(timeLeft <= 9)
        {
            countdown.text = ("0:0" + timeLeft);
        }
        if (timeLeft <= 0)
        {
            GameManager.Instance.GameOver();

        }
    }
    
    
    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}