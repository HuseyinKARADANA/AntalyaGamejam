using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour
{
    private Animator animator;
    private float speed;

    // Oturma ve durma animasyonlarýný tetiklemek için kullanýlacak bekleme süreleri
    public float sitWaitTime = 5f;
    public float idleWaitTime = 3f;

    private float sitTimer;
    private float idleTimer;

    private void Start()
    {
        // Animator bileþenini al
        animator = GetComponent<Animator>();

        // Timers initialized
        sitTimer = sitWaitTime;
        idleTimer = idleWaitTime;
    }

    private void Update()
    {
        // Hýz deðerini güncelle (bu, karakterin hareket mantýðýna göre deðiþtirilmeli)
        // Örnek olarak burada hýz deðerini 0 yapýyoruz, ancak kendi hareket kodunuza göre deðiþtirin
        speed = 0; // Örnek: speed = karakter hýzýnýz;

        // Hýz sýfýrsa timer'larý azalt
        if (speed == 0)
        {
            sitTimer -= Time.deltaTime;
            idleTimer -= Time.deltaTime;

            // Timerlar sýfýra ulaþtýðýnda animasyonlarý tetikleyin
            if (sitTimer <= 0)
            {
                animator.SetTrigger("Sit");
                sitTimer = sitWaitTime; // Timer'ý sýfýrlayýn
            }

            if (idleTimer <= 0)
            {
                animator.SetTrigger("Idle");
                idleTimer = idleWaitTime; // Timer'ý sýfýrlayýn
            }
        }
        else
        {
            // Hýz sýfýr deðilse timer'larý sýfýrla
            sitTimer = sitWaitTime;
            idleTimer = idleWaitTime;
        }

        // "W" tuþuna basýldýðýnda yürüyüþ animasyonunu tetikle
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("Walk");
        }

        
    }
}
