using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{

    /// <summary>
    /// Singleton
    /// </summary>
    private static GameManager instance;

    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private GameObject gameOverPanel;

    public ScoreManager scoreManager;
    public PickupManager pickupManager;
    public UIManager UIManager;
    public Player player;
  
    private float initialSpawnRate = 1f;
    private float spawnRateIncrease = 0.05f;
    private float maxSpawnRate = 2f;

    private float currentSpawnRate;
    private EnemyTypeArray enemyTypes = new EnemyTypeArray();

    public static GameManager GetInstance()
    {
        return instance;
    }

    void SetSingleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }

        instance = this;

    }
    //-------

    private void Awake()
    {
        SetSingleton();
    }

    void Start()
    {
        enemyTypes.enemyTypeArray = enemyPrefabs;
        currentSpawnRate = initialSpawnRate;
        StartCoroutine(EnemySpawner());

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            CreateEnemy();
        }

        if(player == null)
        {
            EndGame();
        }
    }
    private void EndGame()
    {
        gameOverPanel.SetActive(true);
        StopAllCoroutines();
    }

    void CreateEnemy()
    {
        GameObject tempObject = Instantiate(enemyTypes.RandomEnemyType());
        tempObject.transform.position = spawnPositions[Random.Range(0, spawnPositions.Length)].position;
    }

    IEnumerator EnemySpawner()
    {

        while (true)
        {
            yield return new WaitForSeconds(currentSpawnRate);
            CreateEnemy();
            UpdateSpawnRate();
        }

    }
    private void UpdateSpawnRate()
    {
        currentSpawnRate += spawnRateIncrease;
        if (currentSpawnRate > maxSpawnRate)
        {
            currentSpawnRate = maxSpawnRate;
        }
    }
}
