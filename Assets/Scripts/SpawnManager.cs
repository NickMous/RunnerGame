using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject[] obstaclePrefabs;
    public float delayMax = 3;
    public float delayMin = 1;
    public float startDelay = 2;
    public int obstacleBorder = 16;

    // Start is called before the first frame update
    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void SpawnObstacle()
    {
        if (gameManager.isGameActive)
        {
            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[obstacleIndex],
                new Vector3(Random.Range(-obstacleBorder, obstacleBorder), 0, 40),
                obstaclePrefabs[obstacleIndex].transform.rotation);
            Invoke(nameof(SpawnObstacle),
                Random.Range(delayMin / gameManager.difficulty, delayMax / gameManager.difficulty));
        }
    }

    public void StartSpawning()
    {
        Invoke(nameof(SpawnObstacle), startDelay);
        Invoke(nameof(MakeGameHarder), 2);
    }

    private void MakeGameHarder()
    {
        if (gameManager.isGameActive)
        {
            if (delayMax > 0.1f)
            {
                delayMax -= 0.01f;
            }

            if (delayMin > 0.05f)
            {
                delayMin -= 0.005f;
            }

            Invoke(nameof(MakeGameHarder), 2);
        }
    }
}