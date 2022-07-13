using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAddSpawner : MonoBehaviour
{
    public GameObject ItemPrefab;
    public Transform SpawnPosition;
    public float Radius = 1;
    public float spawnTime = 1.0f;


    bool spawnRandom;
    public int spawnRanMax = 2;
    public int spawnRanMin = 0;


    private void Start()
    {
        StartCoroutine(Spawntime());

    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnObjectAtRandom()
    {
        Vector3 randomPos = Random.insideUnitCircle * Radius;
        Instantiate(ItemPrefab, randomPos + transform.position, Quaternion.identity);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(this.transform.position, Radius);
    }
    IEnumerator Spawntime()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);

            spawnTime = Random.Range(0.0f, 1.0f);
            spawnRandom = (Random.Range(spawnRanMin, spawnRanMax) == 0);
            if (spawnRandom == true)
            {
                SpawnObjectAtRandom();

            }
            else
            {

            }
        }
    }

}
