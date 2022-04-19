using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] powerupPrefabs;
    public int powerupIndex;
    public int powerupIndex2;
    public int powerupIndex3;
    public int powerupIndex4;
    public float spawnRangeX = 5.0f;

    public void SpawnPowerUp()
    {
        int powerupIndex = Random.Range(0, powerupPrefabs.Length);
        Instantiate(powerupPrefabs[powerupIndex], new Vector3(Random.Range(-spawnRangeX, -1), 5), powerupPrefabs[powerupIndex].transform.rotation);
    }

    public void SpawnPowerUp2()
    {
        int powerupIndex2 = Random.Range(0, powerupPrefabs.Length);
        Instantiate(powerupPrefabs[powerupIndex2], new Vector3(Random.Range(1, spawnRangeX), 5), powerupPrefabs[powerupIndex2].transform.rotation);
    }

    public void SpawnPowerUp3()
    {
        int powerupIndex3 = Random.Range(0, powerupPrefabs.Length);
        Instantiate(powerupPrefabs[powerupIndex3], new Vector3(Random.Range(1, spawnRangeX), 5), powerupPrefabs[powerupIndex3].transform.rotation);
    }
    public void SpawnPowerUp4()
    {
        int powerupIndex4 = Random.Range(0, powerupPrefabs.Length);
        Instantiate(powerupPrefabs[powerupIndex4], new Vector3(Random.Range(1, spawnRangeX), 5), powerupPrefabs[powerupIndex4].transform.rotation);
    }
}
