using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int enemyCount = 5; 
    private GameObject[] enemies; 
    private Vector3 spawnAreaMin = new Vector3(-5, 0, -5);
    private Vector3 spawnAreaMax = new Vector3(5, 0, 5);

    void Start()
    {
        enemies = new GameObject[enemyCount]; // Initialize array
        SpawnEnemies(); // Spawn initial enemies
    }

    void Update()
    {
        // Loop through enemies array to check for destroyed ones
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] == null) // If an enemy was destroyed, respawn it
            {
                enemies[i] = SpawnEnemy();
            }
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            enemies[i] = SpawnEnemy();
        }
    }

    GameObject SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            0,
            Random.Range(spawnAreaMin.z, spawnAreaMax.z)
        );

        GameObject newEnemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        newEnemy.transform.Rotate(0, Random.Range(0, 360), 0);
        return newEnemy;
    }
}
