using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsSpawner : MonoBehaviour
{
    [SerializeField] BoxCollider2D spawnArea;
    [SerializeField] float powerUpsActiveTime = 7;
    [SerializeField] float powerUpsDeactiveTime = 5;
    [SerializeField] GameObject[] AllpowerUps;

    GameObject power;
    Vector2 randomPosition;
    float totalTime;
    float CurrentTime;
    bool IsPowerUpsSpawned;
    // Start is called before the first frame update
    void Start()
    {
        totalTime = powerUpsActiveTime + powerUpsDeactiveTime;
        CurrentTime = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime -= 1 * Time.deltaTime;
        if(CurrentTime >= (totalTime - powerUpsActiveTime)&& !IsPowerUpsSpawned)
        {
            IsPowerUpsSpawned = true;
            SpawnPowerUps();
        }
        if(CurrentTime <= 0)
        {
            IsPowerUpsSpawned = false;
            DeSpawnPowerUp();
            CurrentTime = totalTime;
        }
    }
    Vector2 GetRanDomPosition()
    {
        Bounds bounds = spawnArea.bounds;
        float x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
        float y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
        return randomPosition;

    }

    void SpawnPowerUps()
    {
        int ranPowerUp = Random.Range(0, AllpowerUps.Length);
        power = AllpowerUps[ranPowerUp];
        power.transform.position = GetRanDomPosition();
        power.SetActive(true);
    }
    void DeSpawnPowerUp()
    {
        if (power)

            power.SetActive(false);
    }
}
