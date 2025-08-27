using UnityEngine;
using UnityEngine.Assertions.Must;

public class SpawnController : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject enemy;
    public float minTime;
    public float maxTime;
    private float spawnTime;

    private float Timer;

    void Awake()
    {
        spawnTime = maxTime;
        Timer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        int spawner = Random.Range(0, spawnPoints.Length);
        if (Timer <= 0)
        {
            Instantiate(enemy, spawnPoints[spawner].transform.position, Quaternion.identity);
            if (spawnTime >= minTime)
            {
                spawnTime -= 0.1f;
            }

            Timer = spawnTime;
        }
    }
}
