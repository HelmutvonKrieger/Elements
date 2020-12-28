using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterControl : MonoBehaviour
{
    public static MasterControl Instance;

    public int CurrentLevelIndex;
    public int NextLevelIndex;

    // Player data
    private int _playerHealth;

    [SerializeField] public int PlayerMaxHealth = 3;

    public int PlayerCurrentHealth
    {
        get => _playerHealth;
        set => setPlayerHealth(value);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void ModifyPlayerHealth(int amount)
    {
        setPlayerHealth(amount);
    }

    private void setPlayerHealth(int amount)
    {
        Debug.LogWarning($"current: {PlayerCurrentHealth}, amount: {amount}");
        if (amount + _playerHealth >= PlayerMaxHealth)
        {
            _playerHealth = PlayerMaxHealth;
            return;
        }

        if (amount + _playerHealth <= 0)
        {
            _playerHealth = 0;
            return;
        }

        _playerHealth = _playerHealth + amount;
    }
}
