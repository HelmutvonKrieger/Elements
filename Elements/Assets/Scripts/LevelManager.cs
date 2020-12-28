using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    public int PickupItemNumber;

    [SerializeField]
    public int EnemyNumber;

    [SerializeField]
    public GameObject pickupItem;

    [SerializeField]
    public GameObject enemyObject;

    public int RemainingItemCount;

    private int prevCount;
    private TextMeshProUGUI tmpro_counter;
    private TextMeshProUGUI tmpro_health;
    private List<Vector3> usedSpawnLocations = new List<Vector3>();
    private int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        // Select the counter and health specifically, in case other TextMeshPro UI elements are present
        tmpro_counter = FindObjectsOfType<TextMeshProUGUI>()
            .Where(tmp => tmp.name == "Counter")
            .FirstOrDefault();

        tmpro_health = FindObjectsOfType<TextMeshProUGUI>()
            .Where(tmp => tmp.name == "Health")
            .FirstOrDefault();

        // Manage level info for transition between levels
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        MasterControl.Instance.CurrentLevelIndex = currentLevel;
        MasterControl.Instance.NextLevelIndex = currentLevel + 1;

        // Manage player health info
        MasterControl.Instance.PlayerCurrentHealth = MasterControl.Instance.PlayerMaxHealth;

        RemainingItemCount = PickupItemNumber;
        SpawnPickupItems();
    }

    // Update is called once per frame
    void Update()
    {
        if (RemainingItemCount != prevCount)
        {
            tmpro_counter.text = $"Objects remaining: {RemainingItemCount}";
            prevCount = RemainingItemCount;
        }

        tmpro_health.text = $"Health: {MasterControl.Instance.PlayerCurrentHealth}";

        if (RemainingItemCount == 0)
        {
            Invoke("EndLevel", 2);
            //EndLevel();
        }
    }

    private void SpawnPickupItems()
    {
        // Spawn each pickup item
        for (int i = 0; i < PickupItemNumber; i++)
        {
            Instantiate(pickupItem, SetSpawnLocation(), Quaternion.identity, transform);
        }

        // Spawn each pickup item
        for (int i = 0; i < EnemyNumber; i++)
        {
            Instantiate(enemyObject, SetSpawnLocation(), Quaternion.identity, transform);
        }
    }

    private Vector3 SetSpawnLocation()
    {
        bool validSpawn = false;

        Vector3 spawnLocation = Vector3.zero;

        // Make sure to get valid spawn location before continuing
        while (!validSpawn)
        {
            // Get random spawn locations for PickupItems
            // TODO: Replace with proper relative sizing when possible
            float randX = Random.Range(-27, 27);
            float randY = Random.Range(-15, 15);

            spawnLocation = new Vector3(randX, randY, 0);

            // Check to make sure location has not been used before
            if (!usedSpawnLocations.Contains(spawnLocation))
            {
                validSpawn = true;
                usedSpawnLocations.Add(spawnLocation);
            }
        }

        return spawnLocation;
    }

    private void EndLevel()
    {
        SceneManager.LoadScene("0_Level Complete");
    }
}
