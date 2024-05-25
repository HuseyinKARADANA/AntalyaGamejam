using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sun : MonoBehaviour
{
    [Range(0, 1)] public float time;
    public float startTime;
    public float dayLength;

    private float timeRate;
    public Vector3 noon;

    public TextMeshProUGUI timeText; // TextMeshPro bile�eni referans�

    public float dayDuration = 10f; // G�nd�z s�resi (dakika)
    public float nightDuration = 10f; // Gece s�resi (dakika)

    public float sunriseHour = 6f; // G�n do�umu saati
    public float sunsetHour = 18f; // G�n bat�m� saati

    private void Start()
    {
        // Toplam g�n uzunlu�u
        dayLength = dayDuration + nightDuration;
        timeRate = 1 / (dayLength * 60); // G�n uzunlu�unu saniyeye �evir
        time = startTime;
    }

    private void Update()
    {
        time += timeRate * Time.deltaTime;
        if (time > 1)
        {
            time = 0;
        }

        // G�n do�umu ve g�n bat�m� zamanlar�n� 0-1 aras� de�erlere �evir
        float sunriseTime = sunriseHour / 24f;
        float sunsetTime = sunsetHour / 24f;

        // G�ne�in d�n���n� ayarlama
        if (time <= sunriseTime || time >= sunsetTime)
        {
            // Gece
            float nightTime = (time >= sunsetTime) ? (time - sunsetTime) / (1f - sunsetTime + sunriseTime) : (time + (1f - sunsetTime)) / (1f - sunsetTime + sunriseTime);
            transform.eulerAngles = Vector3.Lerp(noon, new Vector3(360, 0, 0), nightTime);
        }
        else
        {
            // G�nd�z
            float dayTime = (time - sunriseTime) / (sunsetTime - sunriseTime);
            transform.eulerAngles = Vector3.Lerp(Vector3.zero, noon, dayTime);
        }

        UpdateTimeText();
    }

    private void UpdateTimeText()
    {
        // G�n i�indeki saati hesapla
        float hours = 24 * time;
        int hoursInt = Mathf.FloorToInt(hours);
        int minutesInt = Mathf.FloorToInt((hours - hoursInt) * 60);

        string timeString = string.Format("{0:00}:{1:00}", hoursInt, minutesInt);
        timeText.text = timeString;
    }
}
