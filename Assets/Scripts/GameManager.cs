using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    private SpawnManager spawnManager;
    private TextMeshProUGUI coinsText;
    private TextMeshProUGUI distanceText;
    public GameObject gameOverScreen;
    public GameObject titleScreen;
    public bool isGameActive;
    public float rampUpSpeed = 1;
    public int coins;
    public int coinsToAdd = 10;
    public int difficulty;
    public int distance;

    // Start is called before the first frame update
    private void Start()
    {
        coinsText = GameObject.Find("Coins Text").GetComponent<TextMeshProUGUI>();
        distanceText = GameObject.Find("Distance Text").GetComponent<TextMeshProUGUI>();
        player = GameObject.Find("Player");
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverScreen.SetActive(true);
    }

    public void StartGame(int difficultyChosen)
    {
        difficulty = difficultyChosen;
        isGameActive = true;
        spawnManager.StartSpawning();
        player.GetComponent<PlayerController>().StartRunning();
        titleScreen.SetActive(false);
        Invoke(nameof(UpdateDistance), 0.2f);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateCoins()
    {
        coins += coinsToAdd;
        coinsText.text = "Coins: " + coins;
    }

    public void UpdateDistance()
    {
        if (!isGameActive) return;
        distance++;
        distanceText.text = "Distance: " + distance + "m";
        Invoke(nameof(UpdateDistance), 0.2f);
    }
}