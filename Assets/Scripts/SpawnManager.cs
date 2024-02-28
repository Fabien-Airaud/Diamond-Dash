using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject heartPrefab;
    public GameObject diamondPrefab;

    private readonly float xBound = 5.0f;
    private readonly float zSpawn = 15.0f;

    private readonly float startDelayObstacles = 1.0f;
    private readonly float obstacleSpawnTime = 3.0f;
    private readonly float startDelayDiamonds = 2.0f;
    private readonly float diamondMinSpawnTime = 5.0f;
    private readonly float diamondMaxSpawnTime = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        float spawnTimeDiamond = Random.Range(diamondMinSpawnTime, diamondMaxSpawnTime);
        InvokeRepeating(nameof(SpawnObstacle), startDelayObstacles, obstacleSpawnTime);
        InvokeRepeating(nameof(SpawnDiamond), startDelayDiamonds, spawnTimeDiamond);
        //SpawnHeart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void SpawnObstacle()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        float xSpawn = Random.Range(-xBound, xBound);
        Vector3 spawnPos = new(xSpawn, obstaclePrefabs[obstacleIndex].transform.position.y, zSpawn);

        Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
    }

    private void SpawnHeart()
    {
        float xSpawn = Random.Range(-xBound, xBound);
        Vector3 spawnPos = new(xSpawn, heartPrefab.transform.position.y, zSpawn);

        Instantiate(heartPrefab, spawnPos, heartPrefab.transform.rotation);
    }

    private void SpawnDiamond()
    {
        float xSpawn = Random.Range(-xBound, xBound);
        Vector3 spawnPos = new(xSpawn, diamondPrefab.transform.position.y, zSpawn);

        Instantiate(diamondPrefab, spawnPos, diamondPrefab.transform.rotation);
    }
}
