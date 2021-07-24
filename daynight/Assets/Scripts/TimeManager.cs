using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
   [SerializeField] private Velocity velocity;

    public void pause(){
        Time.timeScale=0;
    }

    public void play1(){
        Time.timeScale=1f;
        velocity.SetValue(1);

    }

    public void play2(){
        velocity.SetValue(10);
    }

    public void play3(){
        velocity.SetValue(30);
    }

}
