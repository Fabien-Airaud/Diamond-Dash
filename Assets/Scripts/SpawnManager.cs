using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject heartPrefab;
    public GameObject diamondPrefab;

    private readonly float xBound = 5.0f;
    private readonly float zSpawn = 15.0f;


    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacle();
        SpawnHeart();
        SpawnDiamond();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void SpawnObstacle()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        float xSpawn = Random.Range(-xBound, xBound);

        Instantiate(obstaclePrefabs[obstacleIndex], new Vector3(xSpawn, 0, zSpawn), obstaclePrefabs[obstacleIndex].transform.rotation);
    }

    private void SpawnHeart()
    {
        float xSpawn = Random.Range(-xBound, xBound);

        Instantiate(heartPrefab, new Vector3(xSpawn, 0, zSpawn), heartPrefab.transform.rotation);
    }

    private void SpawnDiamond()
    {
        float xSpawn = Random.Range(-xBound, xBound);

        Instantiate(diamondPrefab, new Vector3(xSpawn, 0, zSpawn), diamondPrefab.transform.rotation);
    }
}
