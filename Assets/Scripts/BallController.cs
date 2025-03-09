using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public float JumpForce;           // Zıplama gücü
    public Rigidbody2D rb;            // Rigidbody2D referansı
    public string currentColor;       // Mevcut renk
    public Color colorcyan;           // Cyan rengi
    public Color coloryellow;         // Yellow rengi
    public Color colorpink;           // Pink rengi
    public Color colorpurple;         // Purple rengi
    public SpriteRenderer sr;         // SpriteRenderer referansı
    public int star;                  // Yıldız sayısı
    public Text starText;             // Yıldız sayısını gösteren Text
    private bool isMoving = false;    // Topun hareket edip etmediğini kontrol eden flag
    public TextMeshProUGUI startText; // Başlangıç yazısı (Mouse/Space için)

    void Start()
    {
        randomColor(); // Başlangıçta rastgele renk belirle
        rb.velocity = Vector2.zero; // Topu başlangıçta durdur
        rb.gravityScale = 0; // Yerçekimini devre dışı bırak
        startText.gameObject.SetActive(true); // Başlangıç yazısını göster
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Star")
        {
            star++; // Yıldız sayısını artır
            starText.text = star.ToString(); // Yıldız sayısını güncelle
            Destroy(other.gameObject); // Yıldızı yok et
            return;
        }

        if(other.tag == "ColorChanger")
        {
              randomColor(); // Rengi değiştir
              Destroy(other.gameObject); // Renk değiştiriciyi yok et
              return;
        }

        // Topun rengi yanlışsa, sahneyi başa al
        if(other.tag != currentColor)
        {
            SceneManager.LoadScene("StartMenu");
        }
    }

    void Update()
    {
        // Eğer top hareket etmiyorsa ve Space tuşuna ya da mouse tıklamasına basıldığında
        if (!isMoving && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            StartMoving(); // Hareket etmeye başla
        }

        // Eğer top zaten hareket ediyorsa, zıplama yapabilsin
        if (isMoving && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            rb.velocity = Vector2.up * JumpForce; // Topu yukarıya doğru zıplat
        }
    }

    void randomColor()
    {
        int index = Random.Range(0, 4); // Rastgele bir renk seç

        switch(index)
        {
            case 0 : currentColor = "Cyan";
            sr.color = colorcyan; // Cyan rengi
            break;

            case 1 : currentColor = "Yellow";
            sr.color = coloryellow; // Yellow rengi
            break;

            case 2 : currentColor = "Pink";
            sr.color = colorpink; // Pink rengi
            break;

            case 3 : currentColor = "Purple";
            sr.color = colorpurple; // Purple rengi
            break;
        }
    }

    // Topun hareket etmeye başlamasını sağlayan fonksiyon
    void StartMoving()
    {
        isMoving = true; // Hareket etmeye başla
        rb.gravityScale = 1; // Yerçekimini tekrar aç
        rb.velocity = Vector2.up * JumpForce; // İlk zıplamayı yap

        // Başlangıç yazısını kaybolması için yavaşça yok et
        StartCoroutine(FadeOutStartText());
    }

    // Yazının kaybolması için Coroutine
    IEnumerator FadeOutStartText()
    {
        float duration = 1f; // Kaybolma süresi (1 saniye)
        float timeElapsed = 0f;

        Color originalColor = startText.color; // Başlangıç rengini al
        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timeElapsed / duration); // Alpha değerini zamanla azalt
            startText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        // Yazı kaybolduktan sonra tamamen devre dışı bırak
        startText.gameObject.SetActive(false);
    }
}
