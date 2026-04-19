using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float minEnemyInterval = 1f;
    [SerializeField]
    private float maxEnemyInterval = 6f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(Random.Range(minEnemyInterval, maxEnemyInterval), enemyPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(transform.position.x - 1f, transform.position.x + 1), Random.Range(transform.position.y - 2f, transform.position.y + 2f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}