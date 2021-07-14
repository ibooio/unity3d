using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
   
   public static int velocity = 1;

    public void pause(){
        Time.timeScale=0;
    }

    public void play1(){
        Debug.Log("P1");
        Time.timeScale=1f;
        velocity = 1;
    }

    public void play2(){
        Debug.Log("P2");
        velocity = 2;
    }

    public void play3(){
        Debug.Log("P3");
        velocity = 3;
    }

}
