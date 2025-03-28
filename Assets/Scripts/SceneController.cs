using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject iguanaPrefab;
    [SerializeField] private int enemyCount = 5;
    [SerializeField] private Transform iguanaSpawnPt;
    private GameObject[] enemies; 
    private Vector3 spawnAreaMin = new Vector3(-5, 0, -5);
    private Vector3 spawnAreaMax = new Vector3(5, 0, 5);
    [SerializeField] private int iguanasCount = 5;
    private GameObject[] iguanas;

    void Start()
    {
        enemies = new GameObject[enemyCount]; // Initialize array
        SpawnEnemies(); // Spawn initial enemies
        iguanas = new GameObject[iguanasCount]; // Initialize array
        SpawnIguanas(); // Spawn initial enemies
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

    void SpawnIguanas()
    {
        for (int i = 0; i < iguanasCount; i++)
        {
            iguanas[i] = SpawnIguana();
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

    GameObject SpawnIguana()
    {
        Vector3 spawnPos = iguanaSpawnPt.position + new Vector3(
            Random.Range(-2f, 2f), // Small random offset in X
            0,
            Random.Range(-2f, 2f)  // Small random offset in Z
        );

        GameObject newIguana = Instantiate(iguanaPrefab, spawnPos, Quaternion.identity);
        newIguana.transform.Rotate(0, Random.Range(0, 360), 0); // Random rotation
        return newIguana;
    }

}
