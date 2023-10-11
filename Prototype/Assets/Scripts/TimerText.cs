using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour
{
    public Text timerText;
    int seconds;
    public GameObject player;
    public GameObject point;



    void Start (){
        timerText = GetComponent<Text>();
        StartCoroutine(TimerRoutine());
    }

    IEnumerator TimerRoutine(){
        while(true){
            yield return new WaitForSeconds(1);
            seconds += 1;
            timerText.text = seconds.ToString();
        }
        yield return null;
    }


}
