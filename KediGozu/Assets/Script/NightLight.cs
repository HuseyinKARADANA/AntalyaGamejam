using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightLight : MonoBehaviour
{
    public Light[] lights; // Kontrol edilecek ���klar
    public float nightStartTime = 20f; // Gece ba�lama saati (20:00)
    public float nightEndTime = 6f; // Gece biti� saati (06:00)

    private Sun sun; // G�ne� script'inden saati almak i�in referans

    void Start()
    {
        // G�ne� script'ine referans al
        sun = FindObjectOfType<Sun>();
        UpdateLights();
    }

    void Update()
    {
        UpdateLights();
    }

    void UpdateLights()
    {
        float currentTime = sun.time * 24f; // G�ne� script'inden saati al (0-1 aras� de�eri 0-24 saat aral���na �evir)

        if (IsNightTime(currentTime))
        {
            SetLights(true); // Gece ���klar� a�
        }
        else
        {
            SetLights(false); // G�nd�z ���klar� kapat
        }
    }

    bool IsNightTime(float time)
    {
        // Gece zaman� kontrol� (20:00-24:00 ve 00:00-06:00)
        if (nightStartTime > nightEndTime)
        {
            return time >= nightStartTime || time < nightEndTime;
        }
        else
        {
            return time >= nightStartTime && time < nightEndTime;
        }
    }

    void SetLights(bool state)
    {
        foreach (Light light in lights)
        {
            light.enabled = state;
        }
    }
}
