using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int seconds;
    public int min;
    public int sec;
    public Text timer;
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator Countdown()
    {
        timer.text = string.Format("{0}:{1}", min.ToString("00"), sec.ToString("00"));
        seconds = (min * 60) + sec;

        while (seconds > 0)
        {
            yield return new WaitForSeconds(1);

            seconds--;
            sec--;

            if (sec < 0 && min > 0)
            {
                min -= 1;
                sec = 59;
            }
            else if (sec < 0 && min == 0)
            {
                sec = 0;
            }
            timer.text = string.Format("{0}:{1}", min.ToString("00"), sec.ToString("00"));
        }
        
        yield return new WaitForSeconds(1);
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }
    
}
