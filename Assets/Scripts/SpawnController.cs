using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject enemy;
    public GameObject[] spawnPoint;
    public float time;

    private void Update()
    {
        time += Time.deltaTime;

        if (time >= 3)
        {
            time = 0;
            StartCoroutine(RandomSpawn());
        }
    }

    IEnumerator RandomSpawn()
    {
        yield return new WaitForSeconds(Random.Range(1, 4));
        Instantiate(enemy, spawnPoint[Random.Range(0, spawnPoint.Length)].transform.position, Quaternion.identity);
    }
}
