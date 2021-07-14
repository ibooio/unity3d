using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//[ExecuteAlways]
public class LightingManager : MonoBehaviour
{

    [SerializeField]private Light DirectionalLight;
    [SerializeField, Range(0,24)]private float TimeOfDay;
    [SerializeField] TextMeshProUGUI timerReal;
    [SerializeField] TextMeshProUGUI timerGame;

    
    private float deltaTime;

    // tiempo real
    private float day;
    private float hour = 0;
    private float minute = 0;
    private float second = 0;

    // tiempo juego
    private float dayGame;
    private float hourGame = 12;
    private float minuteGame = 0;
    private float secondGame = 0;



    private void Update(){
        deltaTime = Time.deltaTime;
        updateSecond();
        updateSecondGame();
        string newTimeReal = Mathf.FloorToInt(minute).ToString() + ":" + Mathf.FloorToInt(second).ToString();
        string newTimeGame = "Día: " + Mathf.FloorToInt(dayGame).ToString() + " - " + Mathf.FloorToInt(hourGame).ToString() + ":" + Mathf.FloorToInt(minuteGame).ToString();
        timerReal.text = newTimeReal;        
        timerGame.text = newTimeGame;   
        UpdateLighting();
        
    }

    private void updateSecond(){
        second += deltaTime;
        if( second >= 60 ){
            second = 0;
            updateMinute();
        }
    }

    private void updateMinute(){
        minute++;
        if( minute == 60 ){
            minute = 0;
            updateHour();
        }
    }

    private void updateHour(){
        hour++;
        if( hour == 24 ){
            hour = 0;
            updateDay();
        }
    }

    private void updateDay(){
        // :)
    }


    private void updateSecondGame(){
        secondGame += deltaTime;
        //if( secondGame >= 2 ){  // 2 segundo 1 minuto
        //if( secondGame >= 1 ){  // 1 segundo 1 minuto
        //if( secondGame >= 0.1 ){  // 1 segundo 10 minutos
        if( secondGame >= 0.05 ){  // 1 segundo 20 minutos // 3 segudos 1 hora // 1 minuto 12 es un dia
            secondGame = 0;
            updateMinuteGame();
        }
    }

    private void updateMinuteGame(){
        minuteGame++;
        if( minuteGame == 60 ){
            minuteGame = 0;
            updateHourGame();
        }
    }

    private void updateHourGame(){
        hourGame++;
        if( hourGame == 24 ){
            hourGame = 0;
            updateDayGame();
        }
    }

    private void updateDayGame(){
        dayGame++;
    }


    private void UpdateLighting(){
        float percent = hourGame * 100 / 24;
        float grades = (0.25f*(minuteGame+(hourGame*60)))-90;

        //RenderSettings.ambientLight = AmbientColor.Evaluate(percent);
        //RenderSettings.fogColor = FogColor.Evaluate(percent);

        if( DirectionalLight != null ){
           DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3(grades, 0, 0));
        }
    }

}
