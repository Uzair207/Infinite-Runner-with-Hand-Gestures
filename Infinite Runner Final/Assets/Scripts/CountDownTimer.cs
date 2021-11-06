using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public int countDownTimer;
    public Text countDownTimerText;
    public static bool hasCountDownEnded;
    private void Start()
    {
        hasCountDownEnded = false;
        StartCoroutine(CountDown());
    }


    IEnumerator CountDown()
    {
        while (countDownTimer > 0)
        {
            countDownTimerText.text = countDownTimer.ToString();
            yield return new WaitForSeconds(1f);
            countDownTimer--;
        }
        countDownTimerText.text = "Lets Run!";
        yield return new WaitForSeconds(1f);
        countDownTimerText.gameObject.SetActive(false);
        hasCountDownEnded = true;
    }

}
