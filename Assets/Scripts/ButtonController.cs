using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;

    void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    void PlayGame()
    {
        SceneManager.LoadScene("GameScene"); // GameScene yerine sahne adını yaz.
    }

    void QuitGame()
    {
        Application.Quit(); // Oyunu kapatır.
        Debug.Log("Oyun Kapatıldı!"); // Sadece build alınca çalışır.
    }
}
