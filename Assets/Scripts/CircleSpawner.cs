using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject circlePrefab;        // Circle Prefab'ı
    public GameObject colorChangerPrefab;  // Color Changer Prefab'ı
    public GameObject starPrefab;          // Star Prefab'ı
    public Transform player;               // Oyuncu veya takip edilen nesne
    private float lastSpawnY = 0f;         // Son spawn edilen yer
    private float currentSpeed = 50f;      // İlk Circle'ın dönüş hızı (50)

    void Update()
    {
        // Oyuncunun Y konumu her 10 birim arttığında yeni nesneler oluştur
        if (player.position.y >= lastSpawnY + 1)
        {
            SpawnObjects();
            lastSpawnY += 10; // Yeni referans noktası belirle
        }
    }

    void SpawnObjects()
    {
        // Circle Spawn
        Vector3 spawnPosition = new Vector3(0, lastSpawnY + 10, 0);
        GameObject newCircle = Instantiate(circlePrefab, spawnPosition, Quaternion.identity);

        // Circle'ın hızını ayarla
        CircleController circleController = newCircle.GetComponent<CircleController>();
        circleController.speed = currentSpeed;

        // Yeni Circle için hızı 2.5 artır
        currentSpeed += 2.5f;

        // Color Changer Spawn (Circle'dan 5 birim daha yüksek)
        spawnPosition = new Vector3(0, lastSpawnY + 15, 0);
        Instantiate(colorChangerPrefab, spawnPosition, Quaternion.identity);

        // Star Spawn
        spawnPosition = new Vector3(0, lastSpawnY + 10, 0);
        Instantiate(starPrefab, spawnPosition, Quaternion.identity);
    }
}
