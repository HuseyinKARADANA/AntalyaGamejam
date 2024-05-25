using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI; // Duraklatma men�s� referans�
    private bool isPaused = false; // Oyunun duraklat�lm�� olup olmad���n� takip eden de�i�ken

    private void Start()
    {
        // Oyuna ba�lad���nda fareyi gizle ve kilitle
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Resume();
    }

    void Update()
    {
        // ESC tu�una bas�ld���nda oyunu duraklatma veya devam ettirme
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Duraklatma men�s�n� gizle
        Time.timeScale = 1f; // Oyunu devam ettir

        isPaused = false;
        // �mleci Kilitle
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true); // Duraklatma men�s�n� g�ster
        Time.timeScale = 0f; // Oyunu duraklat
        isPaused = true;

        // �mleci g�ster ve serbest b�rak
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
