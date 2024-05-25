using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour
{
    private Animator animator;
    private float speed;

    // Oturma ve durma animasyonlar�n� tetiklemek i�in kullan�lacak bekleme s�releri
    public float sitWaitTime = 5f;
    public float idleWaitTime = 3f;

    private float sitTimer;
    private float idleTimer;

    private void Start()
    {
        // Animator bile�enini al
        animator = GetComponent<Animator>();

        // Timers initialized
        sitTimer = sitWaitTime;
        idleTimer = idleWaitTime;
    }

    private void Update()
    {
        // H�z de�erini g�ncelle (bu, karakterin hareket mant���na g�re de�i�tirilmeli)
        // �rnek olarak burada h�z de�erini 0 yap�yoruz, ancak kendi hareket kodunuza g�re de�i�tirin
        speed = 0; // �rnek: speed = karakter h�z�n�z;

        // H�z s�f�rsa timer'lar� azalt
        if (speed == 0)
        {
            sitTimer -= Time.deltaTime;
            idleTimer -= Time.deltaTime;

            // Timerlar s�f�ra ula�t���nda animasyonlar� tetikleyin
            if (sitTimer <= 0)
            {
                animator.SetTrigger("Sit");
                sitTimer = sitWaitTime; // Timer'� s�f�rlay�n
            }

            if (idleTimer <= 0)
            {
                animator.SetTrigger("Idle");
                idleTimer = idleWaitTime; // Timer'� s�f�rlay�n
            }
        }
        else
        {
            // H�z s�f�r de�ilse timer'lar� s�f�rla
            sitTimer = sitWaitTime;
            idleTimer = idleWaitTime;
        }

        // "W" tu�una bas�ld���nda y�r�y�� animasyonunu tetikle
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("Walk");
        }

        
    }
}
