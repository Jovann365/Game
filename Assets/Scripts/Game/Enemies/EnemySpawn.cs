using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
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
        if (Timer <= 0)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            if (spawnTime >= minTime)
            {
                spawnTime -= 0.1f;
            }
            Timer = spawnTime;
        }
    }
}
